USE ConcreteMixerTruckRoutingDatabase


IF OBJECT_ID('dbo.SubRoute') IS NOT NULL
	DROP TABLE dbo.SubRoute
GO

IF OBJECT_ID('dbo.Route') IS NOT NULL
	DROP TABLE dbo.Route
GO

IF OBJECT_ID('dbo.Address') IS NOT NULL
	DROP TABLE dbo.Address
GO

IF OBJECT_ID('dbo.Construction') IS NOT NULL
	DROP TABLE dbo.Construction
GO

IF OBJECT_ID('dbo.Client') IS NOT NULL
	DROP TABLE dbo.Client
GO

IF OBJECT_ID('dbo.ConcreteType') IS NOT NULL
	DROP TABLE dbo.ConcreteType
GO

IF OBJECT_ID('dbo.ConcreteMixerTruck') IS NOT NULL
	DROP TABLE dbo.ConcreteMixerTruck
GO

----------------------------------------------------------

CREATE TABLE Client (
	ClientId 			INT IDENTITY NOT NULL,
	Name 				VARCHAR(500) NOT NULL,
	ChangeDatetime	 	DATETIME NOT NULL,
	PRIMARY KEY (ClientId)
)

GO

-----------------------------------------------------------------

CREATE TABLE ConcreteType (
	ConcreteTypeId 		INT IDENTITY NOT NULL,
	Description 		VARCHAR(500) NOT NULL,
	Available           BIT NOT NULL,
	ChangeDatetime	 	DATETIME NOT NULL,
	PRIMARY KEY (ConcreteTypeId)
)

GO

-----------------------------------------------------------------

CREATE TABLE Construction (
	ConstructionId 		INT IDENTITY NOT NULL,
	Description 		VARCHAR(500) NOT NULL,
	ClientId 			INT NOT NULL,
	ConcreteTypeId		INT NOT NULL,
	VolumeDemand		DECIMAL(9,2) NOT NULL, -- pois com a precisão 9, reserva-se somente 5 bytes de armazenamento
	Delivered           BIT NOT NULL,
	ChangeDatetime	 	DATETIME NOT NULL,	
	PRIMARY KEY (ConstructionId),
	FOREIGN KEY (ClientId) REFERENCES dbo.Client(ClientId),
	FOREIGN KEY (ConcreteTypeId) REFERENCES dbo.ConcreteType(ConcreteTypeId)
)

GO

-----------------------------------------------------------------

CREATE TABLE Address (
	AddressId 		INT IDENTITY NOT NULL,
	ConstructionId 	INT NOT NULL,
	Street			VARCHAR(500) NOT NULL,
	Number 			INT NULL,
	NoNumber 		BIT NOT NULL,
	Complement 		VARCHAR(500) NULL,
	Neighborhood	VARCHAR(100) NOT NULL,
	ZipCode			VARCHAR(9) NOT NULL,
	City			VARCHAR(100) NOT NULL,
	State			VARCHAR(100) NOT NULL,
	Country			VARCHAR(100) NOT NULL,
	Latitude		DECIMAL(12,9) NOT NULL,
	Longitude 		DECIMAL(12,9) NOT NULL,
	ChangeDatetime	DATETIME NOT NULL,	
	PRIMARY KEY (AddressId),
	FOREIGN KEY (ConstructionId) REFERENCES dbo.Construction(ConstructionId)
)

GO

-----------------------------------------------------------------
-----------------------------------------------------------------

CREATE TABLE ConcreteMixerTruck (
	ConcreteMixerTruckId	INT IDENTITY NOT NULL,
	MaximumCapacity			DECIMAL(9,2) NOT NULL,
	UseCost                 DECIMAL(9,2) NOT NULL,
	Available               BIT NOT NULL,
	ChangeDatetime	 		DATETIME NOT NULL,	
	PRIMARY KEY (ConcreteMixerTruckId)
)

GO

-----------------------------------------------------------------

CREATE TABLE Route (
	RouteId 				INT IDENTITY NOT NULL,
	ConcreteMixerTruckId    INT NOT NULL,
	PRIMARY KEY (RouteId),
	FOREIGN KEY (ConcreteMixerTruckId) REFERENCES dbo.ConcreteMixerTruck(ConcreteMixerTruckId)
)

GO

-----------------------------------------------------------------

CREATE TABLE SubRoute (
	SubRouteId 				INT IDENTITY NOT NULL,
	RouteId 				INT NOT NULL,
	ConstructionOriginId	INT NOT NULL,
	ConstructionDestinyId	INT NOT NULL,	
	PRIMARY KEY (SubRouteId),
	FOREIGN KEY (RouteId) REFERENCES dbo.Route(RouteId),
	FOREIGN KEY (ConstructionOriginId) REFERENCES dbo.Construction(ConstructionId),
	FOREIGN KEY (ConstructionDestinyId) REFERENCES dbo.Construction(ConstructionId)
)

GO