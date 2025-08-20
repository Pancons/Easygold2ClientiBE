using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyGold.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdminUserAndStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Hash password una volta in C# e la iniettiamo nella SQL
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("Abcd1234@");

            migrationBuilder.Sql($@"
                DECLARE @grpId INT, @tipoPwId INT, @negId INT, @uteId INT;

                -- 1) Gruppo Amministratori
                SELECT TOP 1 @grpId = Grp_IDAuto FROM tbcl_gruppi 
                WHERE Grp_NomeGruppo = 'Amministratori' AND (rowdeleted_at IS NULL);

                IF @grpId IS NULL
                BEGIN
                    INSERT INTO tbcl_gruppi (Grp_NomeGruppo, Grp_DesGruppo, Grp_SuperAdmin, Grp_Bloccato, rowcreated_at)
                    VALUES ('Amministratori', 'Gruppo amministratori di sistema', 1, 0, GETUTCDATE());
                    SET @grpId = SCOPE_IDENTITY();
                END

                -- 2) Tipo Password: BCrypt
                SELECT TOP 1 @tipoPwId = Tpp_IDAuto FROM tbcl_tipoPw 
                WHERE Tpp_TipoPw = 'BCrypt' AND (rowdeleted_at IS NULL);

                IF @tipoPwId IS NULL
                BEGIN
                    INSERT INTO tbcl_tipoPw (Tpp_TipoPw, rowcreated_at)
                    VALUES ('BCrypt', GETUTCDATE());
                    SET @tipoPwId = SCOPE_IDENTITY();
                END

                -- 3) Negozio Demo
                SELECT TOP 1 @negId = Neg_id FROM tbcl_negozi 
                WHERE Neg_NomeNegozio = 'Easygold Demo Store' AND (Neg_DataDisattivazione IS NULL);

                IF @negId IS NULL
                BEGIN
                    INSERT INTO tbcl_negozi
                        (Neg_IDCliente, Neg_RagioneSociale,   Neg_NomeNegozio,         Neg_DataAttivazione, Neg_DataDisattivazione, Neg_Bloccato, Neg_DataOraBlocco, Neg_Note)
                    VALUES
                        (1,            'Demo S.r.l.',         'Easygold Demo Store',    GETUTCDATE(),        NULL,                   0,            NULL,              'Negozio creato via migrazione di seed');
                    SET @negId = SCOPE_IDENTITY();
                END

                -- 4) Utente admin
                SELECT TOP 1 @uteId = Ute_IDAuto FROM tbcl_utenti 
                WHERE Ute_IDUtente = 'admin';

                IF @uteId IS NULL
                BEGIN
                    INSERT INTO tbcl_utenti
                        (Ute_IDUtente, Ute_NomeUtente, Ute_IDGruppo, Ute_IDIdioma, Ute_AbilitaTuttiNegozi, Ute_AbilitaCassa, Ute_AbilitaEliminaProd, Ute_Bloccato, Ute_PasswordResetToken, Ute_ResetTokenExpiry, Ute_Email)
                    VALUES
                        ('admin',      'Amministratore', @grpId,      1040,          1,                    1,                0,                     0,            NULL,                   NULL,               'admin@easygold.local');
                    SET @uteId = SCOPE_IDENTITY();
                END
                ELSE
                BEGIN
                    -- Assicura che l'utente sia nel gruppo admin (idempotente)
                    UPDATE tbcl_utenti SET Ute_IDGruppo = @grpId WHERE Ute_IDAuto = @uteId;
                END

                -- 5) Password (tbcl_pwUtenti)
                IF NOT EXISTS (
                    SELECT 1 FROM tbcl_pwUtenti WHERE Utp_IDUtente = @uteId AND Utp_TipoPw = @tipoPwId AND (rowdeleted_at IS NULL)
                )
                BEGIN
                    INSERT INTO tbcl_pwUtenti (Utp_IDUtente, Utp_TipoPw, Utp_PwUtente, rowcreated_at, rowupdated_at, rowdeleted_at)
                    VALUES (@uteId, @tipoPwId, '{passwordHash}', GETUTCDATE(), NULL, NULL);
                END
                ELSE
                BEGIN
                    -- Aggiorna l'hash solo se serve (opzionale, qui lo sovrascriviamo)
                    UPDATE tbcl_pwUtenti SET Utp_PwUtente = '{passwordHash}', rowupdated_at = GETUTCDATE()
                    WHERE Utp_IDUtente = @uteId AND Utp_TipoPw = @tipoPwId AND (rowdeleted_at IS NULL);
                END

                -- 6) Associazione utente <-> negozio (default)
                IF NOT EXISTS (
                    SELECT 1 FROM tbcl_utenteNegozi WHERE Utn_IDUtente = @uteId AND Utn_IDNegozio = @negId AND (rowdeleted_at IS NULL)
                )
                BEGIN
                    INSERT INTO tbcl_utenteNegozi (Utn_IDUtente, Utn_IDNegozio, Utn_Annullato, Utn_Default, rowcreated_at, rowupdated_at, rowdeleted_at)
                    VALUES (@uteId, @negId, 0, 1, GETUTCDATE(), NULL, NULL);
                END
                ");
                        }

                        /// <inheritdoc />
                        protected override void Down(MigrationBuilder migrationBuilder)
                        {
                            migrationBuilder.Sql(@"
                DECLARE @grpId INT, @tipoPwId INT, @negId INT, @uteId INT;

                SELECT TOP 1 @uteId = Ute_IDAuto FROM tbcl_utenti WHERE Ute_IDUtente = 'admin';
                SELECT TOP 1 @negId = Neg_id FROM tbcl_negozi WHERE Neg_NomeNegozio = 'Easygold Demo Store';
                SELECT TOP 1 @grpId = Grp_IDAuto FROM tbcl_gruppi WHERE Grp_NomeGruppo = 'Amministratori';
                SELECT TOP 1 @tipoPwId = Tpp_IDAuto FROM tbcl_tipoPw WHERE Tpp_TipoPw = 'BCrypt';

                -- Rimuovi associazioni/credenziali
                IF @uteId IS NOT NULL AND @negId IS NOT NULL
                    DELETE FROM tbcl_utenteNegozi WHERE Utn_IDUtente = @uteId AND Utn_IDNegozio = @negId;

                IF @uteId IS NOT NULL AND @tipoPwId IS NOT NULL
                    DELETE FROM tbcl_pwUtenti WHERE Utp_IDUtente = @uteId AND Utp_TipoPw = @tipoPwId;

                -- Rimuovi entità principali (ordine che rispetta le FK)
                IF @uteId IS NOT NULL
                    DELETE FROM tbcl_utenti WHERE Ute_IDAuto = @uteId;

                IF @negId IS NOT NULL
                    DELETE FROM tbcl_negozi WHERE Neg_id = @negId;

                IF @tipoPwId IS NOT NULL
                    DELETE FROM tbcl_tipoPw WHERE Tpp_IDAuto = @tipoPwId;

                IF @grpId IS NOT NULL
                    DELETE FROM tbcl_gruppi WHERE Grp_IDAuto = @grpId;
                ");
        }
    }
}
