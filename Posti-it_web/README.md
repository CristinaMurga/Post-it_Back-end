# Sistema di Post-it Virtuali - Back-End

## Descrizione del Progetto
Questo è il back-end di un sistema di post-it virtuali multiutente, sviluppato con .NET. Gestisce le operazioni di registrazione, login, creazione, modifica, eliminazione e spostamento delle note. 
Ogni nota è associata a un utente e include il contenuto, il colore scelto da una lista di colori predefiniti e la posizione sulla lavagna.
I dati sono salvati in un database.

## Come Installare ed Eseguire il Progetto

1. **Prerequisiti:**
   - Assicurati di avere installato [.NET SDK](https://dotnet.microsoft.com/download).
   - Assicurati di avere un database (ad es. SQL Server) in esecuzione.

2. **Clonare la Repository:**
    
    git clone https://github.com/CristinaMurga/Post-it_Back-end.git
    cd Back-end
 

3. **Installare le Dipendenze:**
    Apri il progetto in Visual Studio e ripristina i pacchetti NuGet necessari.

4. **Configurare il Database:**
   - Configura le credenziali del database nel file `appsettings.json`.

5. **Applicare le Migrazioni del Database:**
    Apri il terminale della console di Gestione Pacchetti di Visual Studio e esegui:
 
    Update-Database


6. **Avviare il Server:**
    Premi `Ctrl` + `F5` o usa il comando:
   
    dotnet run
    

## Come Usare il Progetto
Questo back-end è utilizzato dal front-end del sistema di post-it virtuali. 
Assicurati di avere il front-end in esecuzione e configurato correttamente per comunicare con questo back-end.
Puoi trovare le istruzioni per il front-end nella Repository https://github.com/CristinaMurga/Post-It_Front-end.git


1. **API Endpoints:**
   - **Registrazione:** `POST /api/Users` - Registra un nuovo utente.
   - **Login:** `POST /api/login` - Autentica un utente.
   - **Visualizza Note** `GET /api/PostIts/{id}` - Visualizza le note per utente.
   - **Creazione Nota:** `POST /api/PostIts` - Crea una nuova nota.
   - **Modifica Nota:** `PUT /api/PostIts/{id}` - Modifica una nota esistente.
   - **Eliminazione Nota:** `DELETE /api/PostIts/{id}` - Elimina una nota.
  
