CREATE TABLE Utente 
( UtenteID INT PRIMARY KEY IDENTITY (1,1),
 Nome VARCHAR (250) NOT NULL, 
 Cognome  VARCHAR (250) NOT NULL, 
 Email VARCHAR (250) UNIQUE NOT NULL , 

);


CREATE TABLE Libri(
LibroID INT PRIMARY KEY IDENTITY (1,1),
Titolo VARCHAR (250) NOT NULL,
AnnoPubb INT NOT NULL CHECK (AnnoPubb <= YEAR(GETDATE())),
statoDisp BIT  NOT NULL DEFAULT 1 ,
);

CREATE TABLE Prestito (
PrestitoID INT PRIMARY KEY IDENTITY (1,1),
UtenteRif INT NOT NULL ,
LibroRif INT NOT NULL ,
Dataprestito DATE NOT NULL,
Dataritorno DATE NOT NULL,
CONSTRAINT CHK_Dataritorno CHECK (Dataritorno > Dataprestito),
FOREIGN KEY  (UtenteRif) REFERENCES Utente(UtenteID) ON DELETE CASCADE,
FOREIGN KEY  (libroRif) REFERENCES Libri(LibroID) ON DELETE CASCADE,
);

INSERT INTO Utente (Nome, Cognome, Email)
VALUES 
('Mario', 'Rossi', 'mario.rossi@email.com'),
('Luca', 'Bianchi', 'luca.bianchi@email.com'),
('Giulia', 'Verdi', 'giulia.verdi@email.com'),
('Elena', 'Russo', 'elena.russo@email.com'),
('Francesco', 'Esposito', 'francesco.esposito@email.com'),
('Marco', 'Ferrari', 'marco.ferrari@email.com'),
('Laura', 'Romano', 'laura.romano@email.com'),
('Alessia', 'Gallo', 'alessia.gallo@email.com'),
('Giovanni', 'Fontana', 'giovanni.fontana@email.com'),
('Simone', 'Costa', 'simone.costa@email.com');


INSERT INTO Libri (Titolo, AnnoPubb, statoDisp)
VALUES 
('Il Signore degli Anelli', 1954, 0), -- In prestito
('Orgoglio e Pregiudizio', 1813, 1),  -- Disponibile
('Il Codice Da Vinci', 2003, 0),      -- In prestito
('Harry Potter e la Pietra Filosofale', 1997, 0), -- In prestito
('1984', 1949, 1),                    -- Disponibile
('Moby Dick', 1851, 1),               -- Disponibile
('Il Grande Gatsby', 1925, 0),        -- In prestito
('Cime Tempestose', 1847, 1),         -- Disponibile
('Don Chisciotte della Mancia', 1605, 1), -- Disponibile
('La Divina Commedia', 1320, 0);      -- In prestito

INSERT INTO Prestito (UtenteRif, LibroRif, Dataprestito, Dataritorno)
VALUES 
(1, 1, '2024-01-02', '2024-01-16'), -- Il Signore degli Anelli, in prestito
(3, 3, '2024-01-05', '2024-01-20'), -- Il Codice Da Vinci, in prestito
(4, 4, '2024-01-10', '2024-01-25'), -- Harry Potter e la Pietra Filosofale, in prestito
(7, 7, '2024-01-03', '2024-01-18'), -- Il Grande Gatsby, in prestito
(10, 10, '2024-01-01', '2024-01-15'); -- La Divina Commedia, in prestito