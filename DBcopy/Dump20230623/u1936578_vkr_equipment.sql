-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: server42.hosting.reg.ru    Database: u1936578_vkr
-- ------------------------------------------------------
-- Server version	5.7.27-30

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
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `equipment` (
  `idequipment` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(9) CHARACTER SET utf8mb4 NOT NULL,
  `idsubdivision` int(11) NOT NULL,
  `description` text CHARACTER SET utf8mb4 NOT NULL,
  `iduser` int(11) NOT NULL,
  `date` datetime NOT NULL,
  PRIMARY KEY (`idequipment`),
  KEY `user_idx` (`iduser`),
  KEY `subd_idx` (`idsubdivision`),
  CONSTRAINT `subd` FOREIGN KEY (`idsubdivision`) REFERENCES `subdivision` (`idsubdivision`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `user` FOREIGN KEY (`iduser`) REFERENCES `user` (`iduser`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `equipment`
--

LOCK TABLES `equipment` WRITE;
/*!40000 ALTER TABLE `equipment` DISABLE KEYS */;
INSERT INTO `equipment` VALUES (1,'Снайпер 8',1,'Станок фрезерно-гравировальный учебный трехкоординатный с ЧПУ «Снайпер-8» предназначен для обработки легкообрабатываемых материалов.',1,'2020-10-10 03:00:00'),(2,'ЕТ300',1,'Станки электрохимические копировально-прошивочные серии «ЕТ3000» предназначены для выполнения прецизионных копировально-прошивочных технологических операций.',1,'2020-10-10 03:00:00'),(3,'ЦПР-1П',1,'Промышленный робот «ЦПР-1П» предназначается для автоматизации операций загрузки-разгрузки технологического оборудования. Сравнительно небольшой робот с размером манипулятора (610 х 380 х 620) мм и размером стойки управления (400 х 400 х 1000) мм, с весом 135кг, однако маленькой грузоподъёмностью 1кг. ',1,'2020-10-10 03:00:00'),(6,'РФ-202М',1,'Универсальный робот «РФ-202М» предназначен для автоматизации процессов загрузки-разгрузки станков типа прессов и штампов. При этом робот осуществляет захват, перенос и установку заготовки на станок, а после обработки снятие готовой детали. Для этого рука робота оснащена клещевым захватом.',1,'2020-10-10 03:00:00'),(7,'ТУР-10',1,'Промышленный робот «ТУР-10» создан с применением мехатронных модулей второго поколения. Он относиться к роботам универсального типа, используемых для автоматизации основных технологических операций (сварка, сборка, и т.п.) и вспомогательных операций при обслуживании технологического оборудования. Предназначен для автоматизации основных технологических и вспомогательных операций при обслуживании технологического оборудования.',1,'2020-10-10 03:00:00'),(8,'КП-10',1,'Компрессор промышленный модель 10',1,'2020-10-10 03:00:00');
/*!40000 ALTER TABLE `equipment` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-23 12:14:23
