CREATE TABLE gardener (firstname VARCHAR(255), lastname VARCHAR(255), plotid integer, id SERIAL PRIMARY KEY);
INSERT INTO gardener (firstname, lastname, plotid) values ('Rachel', 'Wood', 1);
INSERT INTO gardener (firstname, lastname, plotid) values ('Crystal', 'Elsey', 1);

CREATE TABLE plot (bed VARCHAR(255), id SERIAL PRIMARY KEY);
INSERT INTO plot (bed) values ('Rachel', 'Wood', 1);
INSERT INTO plot (bed) values ('Crystal', 'Elsey', 2);