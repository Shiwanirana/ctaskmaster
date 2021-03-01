use ctaskmaster;
-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE lists
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   title VARCHAR(255) NOT NULL UNIQUE,

--   PRIMARY KEY (id),

--   -- REVIEW[epic=Populate] Establishing a relationship to a foreign key
--   FOREIGN KEY (creatorId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE
-- );
INSERT INTO lists
(title, creatorId)
VALUES
("test title", "fake creator");

-- CREATE TABLE listprofiles
-- (
--    id INT NOT NULL AUTO_INCREMENT,
--    profileId VARCHAR(255) NOT NULL,
--    listId INT NOT NULL,

--   PRIMARY KEY (id),

--   -- REVIEW[epic=many-to-many] Establishing a relationship to a foreign key
--   FOREIGN KEY (profileId)
--    REFERENCES profiles (id)
--    ON DELETE CASCADE,

--   -- REVIEW[epic=many-to-many] Establishing a relationship to a foreign key
--   FOREIGN KEY (listId)
--    REFERENCES lists (id)
--    ON DELETE CASCADE
-- );

CREATE TABLE tasks
(
  id INT NOT NULL AUTO_INCREMENT,
  body VARCHAR(255),
  PRIMARY key(id)
)