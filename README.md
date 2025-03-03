# EasyGold API

![EasyGold API](https://your-image-url.com)

## 📌 Descrizione
EasyGold API è un backend per la gestione di utenti, clienti, moduli e file multimediali. Segue un'architettura **scalabile** e **modulare** basata su **.NET Core**, con separazione tra **controller, servizi e repository**.

## 🚀 Tecnologie Utilizzate
- **.NET Core 6+**
- **Entity Framework Core** (EF Core)
- **AutoMapper**
- **BCrypt.Net** (per hash delle password)
- **JWT Token Authentication**
- **SQL Server**
- **MediatR** (opzionale, per CQRS)

---

## 📂 Struttura del Progetto
```
/EasyGold.API
    /Controllers
        AuthController.cs
        ClienteController.cs
        ModuloController.cs
        UtenteController.cs
        FileController.cs
    
    /Services
        Interfaces/
            IAuthService.cs
            IClienteService.cs
            IModuloService.cs
            IUtenteService.cs
            IFileService.cs
        Implementations/
            AuthService.cs
            ClienteService.cs
            ModuloService.cs
            UtenteService.cs
            FileService.cs
    
    /Repositories
        Interfaces/
            IClienteRepository.cs
            IModuloRepository.cs
            IUtenteRepository.cs
            IFileRepository.cs
        Implementations/
            ClienteRepository.cs
            ModuloRepository.cs
            UtenteRepository.cs
            FileRepository.cs
    
    /Models
        DTOs/
            UserDto.cs
            ClienteDto.cs
            ModuloDto.cs
        Entities/
            DbUtente.cs
            DbCliente.cs
            DbModulo.cs
    
    /Infrastructure
        ApplicationDbContext.cs
        DependencyInjection.cs
```

---

## ⚙️ Installazione e Configurazione
### 1️⃣ Clonare il Repository
```bash
git clone https://github.com/tuo-username/easygold-api.git
cd easygold-api
```

### 2️⃣ Configurare il Database
Modificare `appsettings.json` per connettersi a SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=EasyGoldDB;User Id=sa;Password=YourPassword;"
},
"Jwt": {
  "Secret": "SuperSecretKey123456789"
}
```

### 3️⃣ Eseguire le Migrazioni EF Core
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4️⃣ Avviare il Server
```bash
dotnet run
```
L'API sarà disponibile su `http://localhost:5000`.

---

## 🔑 Autenticazione
L'API utilizza **JWT Token Authentication**.
1. Effettuare il **login**:
   ```bash
   curl -X POST http://localhost:5000/api/auth/login \
        -H "Content-Type: application/json" \
        -d '{"username": "admin", "password": "admin123"}'
   ```
2. Utilizzare il token JWT ricevuto per autenticare le richieste successive.

---

## 📌 Principali Endpoint
### 🔹 Autenticazione
| Metodo | URL | Descrizione |
|--------|----------------------------------|-------------------------------|
| POST | `/api/auth/login` | Autentica un utente e restituisce un JWT |
| POST | `/api/auth/logout` | Effettua il logout |

### 🔹 Clienti
| Metodo | URL | Descrizione |
|--------|--------------------------------|------------------------------------------|
| POST | `/api/clienti/list` | Recupera la lista clienti con filtro e paginazione |
| GET | `/api/clienti/{id}` | Ottiene i dettagli di un cliente |
| POST | `/api/clienti/save` | Salva un cliente con allegati |

### 🔹 Utenti
| Metodo | URL | Descrizione |
|--------|-------------------------------|--------------------------------|
| POST | `/api/users/list` | Recupera la lista utenti con filtri |
| GET | `/api/users/{id}` | Ottiene i dettagli di un utente |
| POST | `/api/users/create` | Crea un nuovo utente |
| POST | `/api/users/update` | Aggiorna un utente esistente |

### 🔹 Moduli
| Metodo | URL | Descrizione |
|--------|-------------------------|------------------------------|
| GET | `/api/moduli/dropdown` | Carica il dropdown dei moduli |

### 🔹 File
| Metodo | URL | Descrizione |
|--------|---------------------------------|------------------------------|
| POST | `/api/media/upload` | Carica un file |
| GET | `/api/media/{id}` | Scarica un file |
| DELETE | `/api/media/{id}` | Cancella un file |

---

## 🛠️ Contributi
Vuoi contribuire? **Forka il repository** e crea una **pull request**!

### 📌 Linee Guida per i Contributi
1. **Crea un branch** per la tua feature:
   ```bash
   git checkout -b feature/nuova-funzionalita
   ```
2. **Esegui i test** prima di inviare il codice:
   ```bash
   dotnet test
   ```
3. **Effettua il commit** e invia la PR:
   ```bash
   git commit -m "Aggiunta nuova funzionalità"
   git push origin feature/nuova-funzionalita
   ```

---

## 📜 Licenza
Questo progetto è distribuito sotto la licenza **MIT**.

---

## 📧 Contatti
Se hai domande, apri un'**issue** o contattaci a **info@easygold.com**.

---

### 🚀 **Ora sei pronto a usare EasyGold API!**

