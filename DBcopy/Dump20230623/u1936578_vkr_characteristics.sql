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
-- Table structure for table `characteristics`
--

DROP TABLE IF EXISTS `characteristics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `characteristics` (
  `equipment_idequipment` int(11) NOT NULL,
  `list_of_characteristics_idcharacteristics` int(11) NOT NULL,
  `value` varchar(17) CHARACTER SET utf8mb4 NOT NULL,
  `unit` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`equipment_idequipment`,`list_of_characteristics_idcharacteristics`),
  KEY `equipment_idx` (`equipment_idequipment`),
  KEY `list_char_idx` (`list_of_characteristics_idcharacteristics`),
  CONSTRAINT `equipment` FOREIGN KEY (`equipment_idequipment`) REFERENCES `equipment` (`idequipment`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `list_char` FOREIGN KEY (`list_of_characteristics_idcharacteristics`) REFERENCES `list_of_characteristics` (`idcharacteristics`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characteristics`
--

LOCK TABLES `characteristics` WRITE;
/*!40000 ALTER TABLE `characteristics` DISABLE KEYS */;
INSERT INTO `characteristics` VALUES (1,1,'200x300x50',NULL),(1,2,'5',NULL),(1,3,'Механический',NULL),(1,4,'1',NULL),(1,5,'Автоматический',NULL),(1,7,'470x560x500',NULL),(1,9,'65',NULL),(1,10,'35',NULL),(1,11,'5',NULL),(1,12,'1',NULL),(2,1,'450х400',NULL),(2,2,'7,5',NULL),(2,3,'Механический',NULL),(2,4,'1',NULL),(2,5,'Автоматический',NULL),(2,6,'2048',NULL),(2,7,'1500х1000х2000',NULL),(2,9,'250',NULL),(2,10,'20',NULL),(2,11,'5',NULL),(2,12,'3',NULL),(3,1,'50 х 1000 х 50',NULL),(3,2,'3',NULL),(3,3,'Пневматический',NULL),(3,4,'1',NULL),(3,5,'Аналитический',NULL),(3,6,'512',NULL),(3,7,'1010 х 780 х 1620',NULL),(3,8,'2',NULL),(3,9,'65',NULL),(3,10,'0',NULL),(3,11,'5',NULL),(3,12,'1',NULL),(6,1,'50 х 1000 х 50',NULL),(6,2,'5',NULL),(6,3,'Пневматический',NULL),(6,4,'2',NULL),(6,5,'Обучение',NULL),(6,6,'1024',NULL),(6,7,'300х500х400',NULL),(6,8,'5',NULL),(6,9,'7',NULL),(6,10,'0',NULL),(6,11,'7',NULL),(6,12,'1',NULL),(7,1,'500 х 1000 х 500',NULL),(7,2,'25',NULL),(7,3,'Механический',NULL),(7,4,'2',NULL),(7,5,'Аналитический',NULL),(7,6,'1024',NULL),(7,7,'1200х480х640',NULL),(7,8,'5',NULL),(7,9,'640',NULL),(7,10,'0',NULL),(7,11,'3',NULL),(7,12,'1',NULL),(8,10,'0',NULL),(8,11,'5',NULL),(8,12,'1',NULL);
/*!40000 ALTER TABLE `characteristics` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-23 12:14:09
