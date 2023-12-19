CREATE DATABASE VIRTUAL;

USE VIRTUAL;

-- Create Artist table
CREATE TABLE Artist (
    ArtistID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Biography TEXT,
    BirthDate DATE,
    Nationality VARCHAR(50),
    Website VARCHAR(255),
    ContactInformation VARCHAR(255)
);

-- Create Artwork table
CREATE TABLE Artwork (
    ArtworkID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255),
    Description TEXT,
    CreationDate DATE,
    Medium VARCHAR(100),
    ImageURL VARCHAR(255),
    ArtistID INT,
    FOREIGN KEY (ArtistID) REFERENCES Artist(ArtistID)
);

-- Create User table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50) unique,
    Password VARCHAR(50),
    Email VARCHAR(100),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOfBirth DATE,
    ProfilePicture VARCHAR(255)
);





-- Create FavoriteArtworks table (Many-to-Many relationship between User and Artwork)
CREATE TABLE FavoriteArtworks (
    UserID INT,
    ArtworkID INT,
    PRIMARY KEY (UserID, ArtworkID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID)
);

-- Create Gallery table
CREATE TABLE Gallery (
    GalleryID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(100),
    Description TEXT,
    Location VARCHAR(255),
    CuratorID INT,
    OpeningHours VARCHAR(255),
    FOREIGN KEY (CuratorID) REFERENCES Artist(ArtistID)
);

-- Create Artwork_Gallery table (Many-to-Many relationship between Artwork and Gallery)
CREATE TABLE Artwork_Gallery (
    ArtworkID INT,
    GalleryID INT,
    PRIMARY KEY (ArtworkID, GalleryID),
    FOREIGN KEY (ArtworkID) REFERENCES Artwork(ArtworkID),
    FOREIGN KEY (GalleryID) REFERENCES Gallery(GalleryID)
);

INSERT INTO Artist(Name,Biography,BirthDate,Nationality,Website,ContactInformation)
VALUES
('arjuncreations', 'exploring the boundaries of artistic expression', '1987-12-19', 'indian', 'www.arjuncreations.com', 'contact_info_1'),
('amitkumar', 'skilled painter with a passion for colors', '1985-09-28', 'indian', 'www.amitkumarart.com', 'contact_info_2'),
('nehaartist', 'expressive sculptor capturing emotions in stone', '1992-02-10', 'indian', 'www.nehaartist.com', 'contact_info_3'),
('sarahcreates', 'versatile artist exploring various mediums', '1988-07-03', 'indian', 'www.sarahcreates.com', 'contact_info_4'),
('vivekartistry', 'innovative artist blending tradition and modernity', '1995-11-15', 'indian', 'www.vivekartistry.com', 'contact_info_5'),
('anushka_paints', 'passionate about bringing canvases to life', '1983-04-22', 'indian', 'www.anushkapaints.com', 'contact_info_6'),
('rohitdesigns', 'boundary-pushing designer with an eye for detail', '1998-08-09', 'indian', 'www.rohitdesigns.com', 'contact_info_7'),
('divyaillustrates', 'captivating the world with intricate illustrations', '1991-01-30', 'indian', 'www.divyaillustrates.com', 'contact_info_8'),
('akashsculpts', 'creating sculptures that tell unique stories', '1980-06-14', 'indian', 'www.akashsculpts.com', 'contact_info_9'),
('poojapaintings', 'transforming emotions into vibrant paintings', '1994-03-07', 'indian', 'www.poojapaintings.com', 'contact_info_10');


INSERT INTO Artwork (Title, Description, CreationDate, Medium, ImageURL, ArtistID)
VALUES
('painting 1', 'beautiful painting 1', '2023-01-01', 'oil on canvas', 'image_url_1', 1),
('landscapeart', 'captivating scenery in vibrant colors', '2023-02-15', 'acrylic on canvas', 'image_url_2', 2),
('abstractexpression', 'emotionally charged abstract masterpiece', '2023-03-20', 'mixed media', 'image_url_3', 3),
('sculptedbeauty', 'elegant sculpture evoking grace and beauty', '2023-04-10', 'marble', 'image_url_4', 4),
('modernfusion', 'fusion of traditional and modern elements', '2023-05-05', 'digital art', 'image_url_5', 5),
('colorfulcanvas', 'vibrant colors blending in harmony', '2023-06-12', 'oil on canvas', 'image_url_6', 6),
('innovativedesign', 'innovative design pushing creative boundaries', '2023-07-08', '3D sculpture', 'image_url_7', 7),
('intricateillustration', 'detailed illustration telling a rich story', '2023-08-25', 'watercolor', 'image_url_8', 8),
('serenesculpture', 'serene sculpture capturing tranquility', '2023-09-14', 'bronze', 'image_url_9', 9),
('expressiveart', 'expressive art conveying deep emotions', '2023-10-03', 'acrylic on canvas', 'image_url_10', 10);
    

INSERT INTO Users (Username, Password, Email, FirstName, LastName, DateOfBirth, ProfilePicture)
VALUES
('user1', 'password1', 'user1@email.com', 'john', 'doe', '1995-08-20', 'profile_picture_1'),
('user2', 'password2', 'user2@email.com', 'alice', 'smith', '1990-03-12', 'profile_picture_2'),
('artlover3', 'pass123', 'artlover3@email.com', 'charlie', 'brown', '1988-11-05', 'profile_picture_3'),
('creative_soul', 'abc@123', 'creativesoul@email.com', 'emma', 'jones', '1993-06-30', 'profile_picture_4'),
('colorfulmind', 'userpass', 'colorfulmind@email.com', 'grace', 'miller', '1997-09-18', 'profile_picture_5'),
('art_enthusiast', 'letmein', 'artenthusiast@email.com', 'isaac', 'roberts', '1985-04-02', 'profile_picture_6'),
('imagination_joy', 'pass1234', 'joyfulmind@email.com', 'kate', 'williams', '1992-12-15', 'profile_picture_7'),
('create_inspire', 'inspireme', 'createinspire@email.com', 'nathan', 'brown', '1994-07-22', 'profile_picture_8'),
('artsoulmate', 'artlover', 'artsoulmate@email.com', 'olivia', 'green', '1980-10-09', 'profile_picture_9'),
('creativemindset', 'creativepass', 'creativemindset@email.com', 'peter', 'davis', '1998-02-28', 'profile_picture_10');



INSERT INTO Gallery (Name, Description, Location, CuratorID, OpeningHours)
VALUES
('fusion_gallery', 'fusion of diverse artistic styles and mediums', 'bhopal', 1, '9:30 am - 7 pm'),
('creative_expressions', 'exploring diverse artistic expressions', 'mumbai', 2, '10 am - 7 pm'),
('serenity_gallery', 'showcasing art that evokes tranquility', 'bangalore', 3, '11 am - 8 pm'),
('urban_vibes_gallery', 'celebrating art inspired by urban life', 'chennai', 4, '9:30 am - 6:30 pm'),
('modern_art_hub', 'hub for modern and contemporary artworks', 'kolkata', 5, '10:30 am - 7:30 pm'),
('vivid_impressions', 'impressions of vivid colors and emotions', 'hyderabad', 6, '9 am - 6 pm'),
('innovation_gallery', 'showcasing innovative and experimental art', 'pune', 7, '10 am - 6 pm'),
('imagine_and_create', 'where imagination meets creation', 'jaipur', 8, '10:30 am - 7 pm'),
('timeless_creations', 'artworks that stand the test of time', 'ahmedabad', 9, '9 am - 5 pm'),
('expressive_artspace', 'creating a space for expressive art forms', 'lucknow', 10, '11 am - 6:30 pm');
    
  
-- Insert into FavoriteArtworks table
INSERT INTO FavoriteArtworks (UserID, ArtworkID)
VALUES
(1, 1),
(1, 2),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9);

-- Insert into Artwork_Gallery table
INSERT INTO Artwork_Gallery (ArtworkID, GalleryID)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);	

ALTER TABLE FavoriteArtworks 
DROP CONSTRAINT FK__FavoriteA__Artwo__403A8C7D;

ALTER TABLE FavoriteArtworks
ADD CONSTRAINT FK__FavoriteA__Artwo__403A8C7D
FOREIGN KEY (ArtworkID)
REFERENCES Artwork (ArtworkID)
ON DELETE CASCADE;

ALTER TABLE Artwork_Gallery
DROP CONSTRAINT FK__Artwork_G__Artwo__45F365D3;

ALTER TABLE Artwork_Gallery
ADD CONSTRAINT FK__Artwork_G__Artwo__45F365D3
FOREIGN KEY (ArtworkID)
REFERENCES Artwork (ArtworkID)
ON DELETE CASCADE;