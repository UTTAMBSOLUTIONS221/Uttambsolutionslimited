CREATE TABLE Uttambsolutionspermission
(
 Permissionid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Permissionname VARCHAR(70) NOT NULL UNIQUE,
 Permissionadmin BIT NOT NULL DEFAULT 0,
 Isactive BIT NOT NULL DEFAULT 1,
 Isdeleted BIT NOT NULL DEFAULT 0
)

CREATE TABLE Uttambsolutionsrole
(
 Roleid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Rolename VARCHAR(70) NOT NULL UNIQUE,
 Roledescription VARCHAR(200) NOT NULL,
 Isactive BIT NOT NULL DEFAULT 1,
 Isdeleted BIT NOT NULL DEFAULT 0,
 Isdefault  BIT NOT NULL DEFAULT 0,
)
CREATE TABLE Uttambsolutionspermissionrole
(
 Permissionroleid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Roleid INT NOT NULL REFERENCES Uttambsolutionsrole(Roleid),
 Permissionid INT NOT NULL REFERENCES Uttambsolutionspermission(Permissionid)
)

CREATE TABLE Uttambsolutionsstaff
(
 Staffid INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Firstname VARCHAR(50) NOT NULL,
 Lastname VARCHAR(50) NOT NULL,
 Emailaddress VARCHAR(100) NOT NULL UNIQUE,
 Phonenumber VARCHAR(20) NOT NULL UNIQUE,
 Roleid INT NOT NULL REFERENCES Uttambsolutionsrole(Roleid),
 Passwords VARCHAR(100) NOT NULL,
 Passwordhash VARCHAR(100) NOT NULL,
 Loginstatus INT NOT NULL DEFAULT 0,
 Confirmemail BIT NOT NULL DEFAULT 0,
 Confirmphone BIT NOT NULL DEFAULT 0,
 Changepassword BIT NOT NULL DEFAULT 0,
 Lastpasswordchange DATETIME NOT NULL DEFAULT GETDATE(),
 Isactive BIT NOT NULL DEFAULT 1,
 Isdeleted BIT NOT NULL DEFAULT 0,
 Isdefault  BIT NOT NULL DEFAULT 0,
 Createdby INT NOT NULL,
 Modifiedby INT NOT NULL,
 Datecreated DATETIME NOT NULL DEFAULT GETDATE(),
 Datemodified DATETIME NOT NULL DEFAULT GETDATE()
)