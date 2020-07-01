INSERT INTO dvd(title, production_year)
VALUES ('Jacob's Ladder', 1990),
('Fight Club', 1999),
('The Shawshank Redemption', 1994),
('The Green Mile', 1999),
('Stalker', 1979)

INSERT INTO customer(first_name, last_name, password_code, registration_date)
VALUES ('Sahsa', 'Deadov', '1337CCBB', 1554173593),
('Kaneki', 'Ken', '432335BC', 1451857452),
('Zigfreed', 'Dragonslayer', 'K565BC13', 1043789123),
('Thor', 'Indra', 'F474AC12', 1266704352)

INSERT INTO offer(id_dvd, id_customer, offer_date, return_date)
VALUES (1, 1, 1554173593, 1557573593),
(2, 2, 1451857452, 1456957452),
(3, 3, 1043789123, 1084607252),
(4, 4, 1266704352, 1268904352)

SELECT *
FROM dvd
WHERE production_year = 1999
ORDER BY title ASC;

SELECT *
FROM dvd
INNER JOIN offer ON dvd.id_dvd = offer.id_dvd
WHERE 
	offer.offer_date <= strftime('%s','now') AND strftime('%s','now') < offer.return_date;