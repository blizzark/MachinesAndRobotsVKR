BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "equipment" (
	"idequipment"	INTEGER NOT NULL UNIQUE,
	"name"	char(255) NOT NULL,
	"idinstitution"	int(11) NOT NULL,
	"description"	text,
	"iduser"	int(11) NOT NULL,
	"date"	date NOT NULL,
	"image"	char(45) NOT NULL,
	"idvideo"	int(11) NOT NULL,
	"idmodel"	int(11) NOT NULL,
	"idliterature"	int(11) NOT NULL,
	PRIMARY KEY("idequipment" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "d_model" (
	"id3d"	INTEGER NOT NULL UNIQUE,
	"name"	varchar(45) NOT NULL,
	"link"	varchar(255) NOT NULL,
	PRIMARY KEY("id3d" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "educational_institution" (
	"idinstitution"	INTEGER NOT NULL UNIQUE,
	"name"	varchar(255) NOT NULL,
	PRIMARY KEY("idinstitution" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "list_of_characteristics" (
	"idcharacteristics"	INTEGER NOT NULL UNIQUE,
	"name"	varchar(45) NOT NULL,
	PRIMARY KEY("idcharacteristics" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "literature" (
	"idliterature"	INTEGER NOT NULL UNIQUE,
	"name"	varchar(45) NOT NULL,
	"link"	varchar(255) NOT NULL,
	PRIMARY KEY("idliterature" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "user" (
	"iduser"	INTEGER NOT NULL UNIQUE,
	"login"	varchar(45) NOT NULL,
	"pass"	varchar(45) NOT NULL,
	"role"	varchar(45) NOT NULL,
	PRIMARY KEY("iduser" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "video" (
	"idvideo"	INTEGER NOT NULL UNIQUE,
	"name"	varchar(45) NOT NULL,
	"link"	varchar(255) NOT NULL,
	PRIMARY KEY("idvideo" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "characteristics" (
	"equipment_idequipment"	int(11) NOT NULL,
	"list_of_characteristics_idcharacteristics"	int(11) NOT NULL,
	"value"	varchar(255) NOT NULL,
	FOREIGN KEY("list_of_characteristics_idcharacteristics") REFERENCES "list_of_characteristics"("idcharacteristics"),
	FOREIGN KEY("equipment_idequipment") REFERENCES "equipment"("idequipment")
);
INSERT INTO "equipment" ("idequipment","name","idinstitution","description","iduser","date","image","idvideo","idmodel","idliterature") VALUES (1,'Снайпер 8',1,'Станок фрезерно-гравировальный учебный трехкоординатный с ЧПУ «Снайпер-8» предназначен для обработки легкообрабатываемых материалов.',1,'2004-12-22','sniper.png',1,7,6);
INSERT INTO "equipment" ("idequipment","name","idinstitution","description","iduser","date","image","idvideo","idmodel","idliterature") VALUES (2,'ЕТ3000',1,'Станки электрохимические копировально-прошивочные серии «ЕТ3000» предназначены для выполнения прецизионных копировально-прошивочных технологических операций.',1,'2004-12-22','ET.png',11,8,3);
INSERT INTO "equipment" ("idequipment","name","idinstitution","description","iduser","date","image","idvideo","idmodel","idliterature") VALUES (3,'ЦПР-1П',1,'Промышленный робот «ЦПР-1П» предназначается для автоматизации операций загрузки-разгрузки технологического оборудования. Сравнительно небольшой робот с размером манипулятора (610 х 380 х 620) мм и размером стойки управления (400 х 400 х 1000) мм, с весом 135кг, однако маленькой грузоподъёмностью 1кг. ',1,'2006-12-22','CPR.png',12,9,4);
INSERT INTO "equipment" ("idequipment","name","idinstitution","description","iduser","date","image","idvideo","idmodel","idliterature") VALUES (6,'РФ-202М',1,'Универсальный робот «РФ-202М» предназначен для автоматизации процессов загрузки-разгрузки станков типа прессов и штампов. При этом робот осуществляет захват, перенос и установку заготовки на станок, а после обработки снятие готовой детали. Для этого рука робота оснащена клещевым захватом.',1,'2003-12-22','rf202.png',13,10,11);
INSERT INTO "equipment" ("idequipment","name","idinstitution","description","iduser","date","image","idvideo","idmodel","idliterature") VALUES (7,'ТУР-10',1,'Промышленный робот «ТУР-10» создан с применением мехатронных модулей второго поколения. Он относиться к роботам универсального типа, используемых для автоматизации основных технологических операций (сварка, сборка, и т.п.) и вспомогательных операций при обслуживании технологического оборудования. Предназначен для автоматизации основных технологических и вспомогательных операций при обслуживании технологического оборудования.',1,'2001-12-22','tur.png',10,6,10);
INSERT INTO "d_model" ("id3d","name","link") VALUES (1,'Кубик для снайпера 8','untitled1.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (2,'Рука','Deer.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (3,'2','tor1.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (4,'3','3');
INSERT INTO "d_model" ("id3d","name","link") VALUES (5,'44','4');
INSERT INTO "d_model" ("id3d","name","link") VALUES (6,'Рука','untitled1.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (7,'Камень для снайпера','tor1.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (8,'Олень для ЕТ','Deer.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (9,'Оскар для ЦПР','D1201A057.obj');
INSERT INTO "d_model" ("id3d","name","link") VALUES (10,'Принтер для РФ','001.obj');
INSERT INTO "educational_institution" ("idinstitution","name") VALUES (1,'СПбГТИ(ТУ)');
INSERT INTO "educational_institution" ("idinstitution","name") VALUES (2,'СПбПУ');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (1,'Размеры рабочей поверхности стола, мм  ');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (2,'Максимальный вес заготовки, кг');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (3,'Привод');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (4,'Количество захватных устройств');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (5,'Cпособ программирования');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (6,'Объем оперативной памяти МКП, байт');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (7,'Габариты, мм');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (8,'Число степеней подвижности');
INSERT INTO "list_of_characteristics" ("idcharacteristics","name") VALUES (9,'Масса станка, кг');
INSERT INTO "literature" ("idliterature","name","link") VALUES (1,'Лит-ра для ТУР-10','ТУР-10.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (2,'Лит-ра для РФ-202М','РФ-202М.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (3,'Лит-ра для ET3000','ET3000.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (4,'Лит-ра для ЦПР-1П','ЦПР-1П.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (5,'Лит-ра для Снайпер 8','снайпер1.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (6,'Лит-ра для Снайпер 8 2','снайпер.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (10,'Тур','ТУР-10.htm');
INSERT INTO "literature" ("idliterature","name","link") VALUES (11,'Тест для РФ','РФ-202М.htm');
INSERT INTO "user" ("iduser","login","pass","role") VALUES (1,'Администратор','admin','admin');
INSERT INTO "user" ("iduser","login","pass","role") VALUES (2,'Пользователь','user','Любые другие - не админ');
INSERT INTO "video" ("idvideo","name","link") VALUES (1,'Для Снайпера 8','снайпер.mp4');
INSERT INTO "video" ("idvideo","name","link") VALUES (10,'Видео про станок ТУР-10','tur.mp4');
INSERT INTO "video" ("idvideo","name","link") VALUES (11,'Видео для ет3000','ет3000.mp4');
INSERT INTO "video" ("idvideo","name","link") VALUES (12,'Видео для ЦПР','1.mp4');
INSERT INTO "video" ("idvideo","name","link") VALUES (13,'Видео РФ-202','1.mp4');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,1,'200x300x50');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,2,'5');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,3,'Механический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,4,'1');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,5,'Автоматический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,7,'470x560x500');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (1,9,'65');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,1,'450х400');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,2,'7,5');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,3,'Механический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,4,'1');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,5,'Автоматический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,6,'2048');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,7,'1500х1000х2000');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (2,9,'250');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,1,'50 х 1000 х 50');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,2,'3');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,3,'Пневматический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,4,'1');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,5,'Аналитический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,6,'512');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,7,'1010 х 780 х 1620');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,8,'2');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (3,9,'65');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,1,'50 х 1000 х 50');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,2,'5');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,3,'Пневматический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,4,'2');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,5,'Обучение');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,6,'1024');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,7,'300х500х400');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,8,'5');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (6,9,'7');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,1,'500 х 1000 х 500');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,2,'25');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,3,'Механический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,4,'2');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,5,'Аналитический');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,6,'1024');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,7,'1200х480х640');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,8,'5');
INSERT INTO "characteristics" ("equipment_idequipment","list_of_characteristics_idcharacteristics","value") VALUES (7,9,'640');
COMMIT;
