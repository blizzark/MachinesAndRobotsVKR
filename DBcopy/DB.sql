CREATE DATABASE  IF NOT EXISTS `VUk2rScUVg` /*!40100 DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci */;
USE `VUk2rScUVg`;
-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: remotemysql.com    Database: VUk2rScUVg
-- ------------------------------------------------------
-- Server version	8.0.13-4

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `3d_model`
--

DROP TABLE IF EXISTS `3d_model`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `3d_model` (
  `id3d` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`id3d`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `3d_model`
--

LOCK TABLES `3d_model` WRITE;
/*!40000 ALTER TABLE `3d_model` DISABLE KEYS */;
INSERT INTO `3d_model` VALUES (1,'Кубик для снайпера 8','untitled1.obj'),(2,'Рука','Deer.obj'),(3,'2','tor1.obj'),(4,'3','3'),(5,'44','4'),(6,'Рука','untitled1.obj'),(7,'Камень для снайпера','tor1.obj'),(8,'Олень для ЕТ','Deer.obj'),(9,'Оскар для ЦПР','D1201A057.obj'),(10,'Принтер для РФ','001.obj');
/*!40000 ALTER TABLE `3d_model` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characteristics`
--

DROP TABLE IF EXISTS `characteristics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characteristics` (
  `equipment_idequipment` int(11) NOT NULL,
  `list_of_characteristics_idcharacteristics` int(11) NOT NULL,
  `value` varchar(255) NOT NULL,
  PRIMARY KEY (`equipment_idequipment`,`list_of_characteristics_idcharacteristics`),
  KEY `fk_equipment_has_list_of_characteristics_list_of_characteri_idx` (`list_of_characteristics_idcharacteristics`),
  KEY `fk_equipment_has_list_of_characteristics_equipment1_idx` (`equipment_idequipment`),
  CONSTRAINT `fk_equipment_has_list_of_characteristics_equipment1` FOREIGN KEY (`equipment_idequipment`) REFERENCES `equipment` (`idequipment`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_equipment_has_list_of_characteristics_list_of_characterist1` FOREIGN KEY (`list_of_characteristics_idcharacteristics`) REFERENCES `list_of_characteristics` (`idcharacteristics`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characteristics`
--

LOCK TABLES `characteristics` WRITE;
/*!40000 ALTER TABLE `characteristics` DISABLE KEYS */;
INSERT INTO `characteristics` VALUES (1,1,'200x300x50'),(1,2,'5'),(1,3,'Механический'),(1,4,'1'),(1,5,'Автоматический'),(1,7,'470x560x500'),(1,9,'65'),(2,1,'450х400'),(2,2,'7,5'),(2,3,'Механический'),(2,4,'1'),(2,5,'Автоматический'),(2,6,'2048'),(2,7,'1500х1000х2000'),(2,9,'250'),(3,1,'50 х 1000 х 50'),(3,2,'3'),(3,3,'Пневматический'),(3,4,'1'),(3,5,'Аналитический'),(3,6,'512'),(3,7,'1010 х 780 х 1620'),(3,8,'2'),(3,9,'65'),(6,1,'50 х 1000 х 50'),(6,2,'5'),(6,3,'Пневматический'),(6,4,'2'),(6,5,'Обучение'),(6,6,'1024'),(6,7,'300х500х400'),(6,8,'5'),(6,9,'7'),(7,1,'500 х 1000 х 500'),(7,2,'25'),(7,3,'Механический'),(7,4,'2'),(7,5,'Аналитический'),(7,6,'1024'),(7,7,'1200х480х640'),(7,8,'5'),(7,9,'640');
/*!40000 ALTER TABLE `characteristics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `educational_institution`
--

DROP TABLE IF EXISTS `educational_institution`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `educational_institution` (
  `idinstitution` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  PRIMARY KEY (`idinstitution`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `educational_institution`
--

LOCK TABLES `educational_institution` WRITE;
/*!40000 ALTER TABLE `educational_institution` DISABLE KEYS */;
INSERT INTO `educational_institution` VALUES (1,'СПбГТИ(ТУ)'),(2,'СПбПУ');
/*!40000 ALTER TABLE `educational_institution` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipment` (
  `idequipment` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `idinstitution` int(11) NOT NULL,
  `description` longtext,
  `iduser` int(11) NOT NULL,
  `date` date NOT NULL,
  `image` varchar(45) NOT NULL,
  `idvideo` int(11) NOT NULL,
  `idmodel` int(11) NOT NULL,
  `idliterature` int(11) NOT NULL,
  PRIMARY KEY (`idequipment`),
  KEY `iduser_idx` (`iduser`),
  KEY `idinstitution_idx` (`idinstitution`),
  KEY `idmodel_idx` (`idmodel`),
  KEY `idvideo_idx` (`idvideo`),
  KEY `idliterature_idx` (`idliterature`),
  CONSTRAINT `id3d` FOREIGN KEY (`idmodel`) REFERENCES `3d_model` (`id3d`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `idinstitution` FOREIGN KEY (`idinstitution`) REFERENCES `educational_institution` (`idinstitution`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `idliterature` FOREIGN KEY (`idliterature`) REFERENCES `literature` (`idliterature`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `iduser` FOREIGN KEY (`iduser`) REFERENCES `user` (`iduser`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `idvideo` FOREIGN KEY (`idvideo`) REFERENCES `video` (`idvideo`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (1,'Снайпер 8',1,'Станок фрезерно-гравировальный учебный трехкоординатный с ЧПУ «Снайпер-8» предназначен для обработки легкообрабатываемых материалов.',1,'2004-12-22','sniper.png',1,7,6),(2,'ЕТ3000',1,'Станки электрохимические копировально-прошивочные серии «ЕТ3000» предназначены для выполнения прецизионных копировально-прошивочных технологических операций.',1,'2004-12-22','ET.png',11,8,3),(3,'ЦПР-1П',1,'Промышленный робот «ЦПР-1П» предназначается для автоматизации операций загрузки-разгрузки технологического оборудования. Сравнительно небольшой робот с размером манипулятора (610 х 380 х 620) мм и размером стойки управления (400 х 400 х 1000) мм, с весом 135кг, однако маленькой грузоподъёмностью 1кг. ',1,'2006-12-22','CPR.png',12,9,4),(6,'РФ-202М',1,'Универсальный робот «РФ-202М» предназначен для автоматизации процессов загрузки-разгрузки станков типа прессов и штампов. При этом робот осуществляет захват, перенос и установку заготовки на станок, а после обработки снятие готовой детали. Для этого рука робота оснащена клещевым захватом.',1,'2003-12-22','rf202.png',13,10,11),(7,'ТУР-10',1,'Промышленный робот «ТУР-10» создан с применением мехатронных модулей второго поколения. Он относиться к роботам универсального типа, используемых для автоматизации основных технологических операций (сварка, сборка, и т.п.) и вспомогательных операций при обслуживании технологического оборудования. Предназначен для автоматизации основных технологических и вспомогательных операций при обслуживании технологического оборудования.',1,'2001-12-22','tur.png',10,6,10);
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `list_of_characteristics`
--

DROP TABLE IF EXISTS `list_of_characteristics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list_of_characteristics` (
  `idcharacteristics` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idcharacteristics`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list_of_characteristics`
--

LOCK TABLES `list_of_characteristics` WRITE;
/*!40000 ALTER TABLE `list_of_characteristics` DISABLE KEYS */;
INSERT INTO `list_of_characteristics` VALUES (1,'Размеры рабочей поверхности стола, мм  '),(2,'Максимальный вес заготовки, кг'),(3,'Привод'),(4,'Количество захватных устройств'),(5,'Cпособ программирования'),(6,'Объем оперативной памяти МКП, байт'),(7,'Габариты, мм'),(8,'Число степеней подвижности'),(9,'Масса станка, кг');
/*!40000 ALTER TABLE `list_of_characteristics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `literature`
--

DROP TABLE IF EXISTS `literature`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `literature` (
  `idliterature` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`idliterature`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `literature`
--

LOCK TABLES `literature` WRITE;
/*!40000 ALTER TABLE `literature` DISABLE KEYS */;
INSERT INTO `literature` VALUES (1,'Лит-ра для ТУР-10','ТУР-10.htm'),(2,'Лит-ра для РФ-202М','РФ-202М.htm'),(3,'Лит-ра для ET3000','ET3000.htm'),(4,'Лит-ра для ЦПР-1П','ЦПР-1П.htm'),(5,'Лит-ра для Снайпер 8','снайпер1.htm'),(6,'Лит-ра для Снайпер 8 2','снайпер.htm'),(10,'Тур','ТУР-10.htm'),(11,'Тест для РФ','РФ-202М.htm');
/*!40000 ALTER TABLE `literature` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `iduser` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(45) NOT NULL,
  `pass` varchar(45) NOT NULL,
  `role` varchar(45) NOT NULL,
  PRIMARY KEY (`iduser`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'Администратор','admin','admin'),(2,'Пользователь','user','Любые другие - не админ');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `video`
--

DROP TABLE IF EXISTS `video`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `video` (
  `idvideo` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `link` varchar(255) NOT NULL,
  PRIMARY KEY (`idvideo`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `video`
--

LOCK TABLES `video` WRITE;
/*!40000 ALTER TABLE `video` DISABLE KEYS */;
INSERT INTO `video` VALUES (1,'Для Снайпера 8','снайпер.mp4'),(10,'Видео про станок ТУР-10','tur.mp4'),(11,'Видео для ет3000','ет3000.mp4'),(12,'Видео для ЦПР','1.mp4'),(13,'Видео РФ-202','1.mp4');
/*!40000 ALTER TABLE `video` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-23 19:33:59
