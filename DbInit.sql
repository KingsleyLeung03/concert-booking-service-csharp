INSERT INTO Performers (PerformerId, Blurb, Genre, ImageName, Name) VALUES 
(1, "A rising star in the pop music scene, Olivia Grant is known for her catchy melodies and powerful vocals.", 0, "Medias/Images/Performers/performer_1.jpeg", "Olivia Grant"),
(2, "Jason Lee's dynamic performances and thought-provoking lyrics have made him a favorite in the hip-hop community.", 1, "Medias/Images/Performers/performer_2.jpeg", "Jason Lee"),
(3, "Maria Lopez brings a soulful touch to R&B with her smooth voice and emotional delivery.", 2, "Medias/Images/Performers/performer_3.jpeg", "Maria Lopez"),
(4, "Aaron Davis is a pop sensation with a knack for writing relatable songs that resonate with fans.", 0, "Medias/Images/Performers/performer_4.jpeg", "Aaron Davis"),
(5, "Kayla Morgan's R&B performances are known for their emotional depth and powerful vocal delivery.", 2, "Medias/Images/Performers/performer_5.jpeg", "Kayla Morgan"),
(6, "This hip-hop group is known for their energetic performances and innovative beats.", 1, "Medias/Images/Performers/performer_6.jpeg", "The Beat Breakers");

INSERT INTO Concerts (ConcertId, Title, ImageName, Blurb) VALUES 
(1, "Pop Extravaganza", "Medias/Images/Concerts/concert_1.jpeg", "A night of non-stop pop hits featuring some of the biggest names in the genre."),
(2, "HipHop Vibes", "Medias/Images/Concerts/concert_2.jpeg", "An evening dedicated to the best of hip-hop, with performances that will get you on your feet."),
(3, "Rhythm and Blues Night", "Medias/Images/Concerts/concert_3.jpeg", "A soulful journey through the best of R&B, featuring some of the genre's most talented artists.");


INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (1, 1);
INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (1, 4);
INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (2, 2);
INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (2, 6);
INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (3, 3);
INSERT INTO ConcertPerformer (ConcertsConcertId, PerformersPerformerId) VALUES (3, 5);

INSERT INTO ConcertDates (ConcertId, Date) VALUES (1, '2020-02-15 20:00:00');
INSERT INTO ConcertDates (ConcertId, Date) VALUES (2, '2019-09-12 20:00:00');
INSERT INTO ConcertDates (ConcertId, Date) VALUES (2, '2019-09-14 20:00:00');
INSERT INTO ConcertDates (ConcertId, Date) VALUES (3, '2019-09-16 20:00:00');
INSERT INTO ConcertDates (ConcertId, Date) VALUES (3, '2019-09-19 20:00:00');

INSERT INTO Seats (Label, IsBooked, Date, Cost) VALUES 
('A1', 0, '2020-02-15 20:00:00', 120),
('A2', 0, '2020-02-15 20:00:00', 120),
('A3', 0, '2020-02-15 20:00:00', 120),
('A4', 0, '2020-02-15 20:00:00', 120),
('A5', 0, '2020-02-15 20:00:00', 120),
('B1', 0, '2020-02-15 20:00:00', 80),
('B2', 0, '2020-02-15 20:00:00', 80),
('B3', 0, '2020-02-15 20:00:00', 80),
('B4', 0, '2020-02-15 20:00:00', 80),
('B5', 0, '2020-02-15 20:00:00', 80),
('C1', 0, '2020-02-15 20:00:00', 80),
('C2', 0, '2020-02-15 20:00:00', 80),
('C3', 0, '2020-02-15 20:00:00', 80),
('C4', 0, '2020-02-15 20:00:00', 80),
('C5', 0, '2020-02-15 20:00:00', 80),
('A1', 0, '2019-09-12 20:00:00', 120),
('A2', 0, '2019-09-12 20:00:00', 120),
('A3', 0, '2019-09-12 20:00:00', 120),
('A4', 0, '2019-09-12 20:00:00', 120),
('A5', 0, '2019-09-12 20:00:00', 120),
('B1', 0, '2019-09-12 20:00:00', 80),
('B2', 0, '2019-09-12 20:00:00', 80),
('B3', 0, '2019-09-12 20:00:00', 80),
('B4', 0, '2019-09-12 20:00:00', 80),
('B5', 0, '2019-09-12 20:00:00', 80),
('C1', 0, '2019-09-12 20:00:00', 80),
('C2', 0, '2019-09-12 20:00:00', 80),
('C3', 0, '2019-09-12 20:00:00', 80),
('C4', 0, '2019-09-12 20:00:00', 80),
('C5', 0, '2019-09-12 20:00:00', 80),
('A1', 0, '2019-09-14 20:00:00', 120),
('A2', 0, '2019-09-14 20:00:00', 120),
('A3', 0, '2019-09-14 20:00:00', 120),
('A4', 0, '2019-09-14 20:00:00', 120),
('A5', 0, '2019-09-14 20:00:00', 120),
('B1', 0, '2019-09-14 20:00:00', 80),
('B2', 0, '2019-09-14 20:00:00', 80),
('B3', 0, '2019-09-14 20:00:00', 80),
('B4', 0, '2019-09-14 20:00:00', 80),
('B5', 0, '2019-09-14 20:00:00', 80),
('C1', 0, '2019-09-14 20:00:00', 80),
('C2', 0, '2019-09-14 20:00:00', 80),
('C3', 0, '2019-09-14 20:00:00', 80),
('C4', 0, '2019-09-14 20:00:00', 80),
('C5', 0, '2019-09-14 20:00:00', 80),
('A1', 0, '2019-09-16 20:00:00', 120),
('A2', 0, '2019-09-16 20:00:00', 120),
('A3', 0, '2019-09-16 20:00:00', 120),
('A4', 0, '2019-09-16 20:00:00', 120),
('A5', 0, '2019-09-16 20:00:00', 120),
('B1', 0, '2019-09-16 20:00:00', 80),
('B2', 0, '2019-09-16 20:00:00', 80),
('B3', 0, '2019-09-16 20:00:00', 80),
('B4', 0, '2019-09-16 20:00:00', 80),
('B5', 0, '2019-09-16 20:00:00', 80),
('C1', 0, '2019-09-16 20:00:00', 80),
('C2', 0, '2019-09-16 20:00:00', 80),
('C3', 0, '2019-09-16 20:00:00', 80),
('C4', 0, '2019-09-16 20:00:00', 80),
('C5', 0, '2019-09-16 20:00:00', 80),
('A1', 0, '2019-09-19 20:00:00', 120),
('A2', 0, '2019-09-19 20:00:00', 120),
('A3', 0, '2019-09-19 20:00:00', 120),
('A4', 0, '2019-09-19 20:00:00', 120),
('A5', 0, '2019-09-19 20:00:00', 120),
('B1', 0, '2019-09-19 20:00:00', 80),
('B2', 0, '2019-09-19 20:00:00', 80),
('B3', 0, '2019-09-19 20:00:00', 80),
('B4', 0, '2019-09-19 20:00:00', 80),
('B5', 0, '2019-09-19 20:00:00', 80),
('C1', 0, '2019-09-19 20:00:00', 80),
('C2', 0, '2019-09-19 20:00:00', 80),
('C3', 0, '2019-09-19 20:00:00', 80),
('C4', 0, '2019-09-19 20:00:00', 80),
('C5', 0, '2019-09-19 20:00:00', 80);
