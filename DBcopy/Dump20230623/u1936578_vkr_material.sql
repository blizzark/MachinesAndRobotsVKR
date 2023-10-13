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
-- Table structure for table `material`
--

DROP TABLE IF EXISTS `material`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `material` (
  `idmaterial` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) CHARACTER SET utf8mb4 NOT NULL,
  `link` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `idmaterial_type` int(11) NOT NULL,
  `idequipment` int(11) NOT NULL,
  PRIMARY KEY (`idmaterial`),
  KEY `idtype_idx` (`idmaterial_type`),
  KEY `ideq_idx` (`idequipment`),
  CONSTRAINT `ideq` FOREIGN KEY (`idequipment`) REFERENCES `equipment` (`idequipment`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `idtype` FOREIGN KEY (`idmaterial_type`) REFERENCES `material` (`idmaterial`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `material`
--

LOCK TABLES `material` WRITE;
/*!40000 ALTER TABLE `material` DISABLE KEYS */;
INSERT INTO `material` VALUES (1,'Для Снайпера 8','снайпер.mp4',1,1),(2,'Видео про станок ТУР-10','tur.mp4',1,7),(3,'Видео для ет3000','ет3000.mp4',1,2),(4,'Видео для ЦПР','1.mp4',1,3),(5,'Видео РФ-202','1.mp4',1,6),(6,'Лит-ра для ТУР-10','ТУР-10.htm',3,7),(7,'Лит-ра для РФ-202М','РФ-202М.htm',3,6),(8,'Лит-ра для ET3000','ET3000.htm',3,2),(9,'Лит-ра для ЦПР-1П','ЦПР-1П.htm',3,3),(10,'Лит-ра для Снайпер 8','снайпер.htm',3,1),(11,'Лит-ра для Снайпер 8 2','снайпер.htm',3,1),(12,'Тур','ТУР-10.htm',3,7),(13,'Тест для РФ','РФ-202М.htm',3,6),(14,'Компрессор КП-1','compr.obj',2,8),(16,'Снайпер 8','sniper.obj',2,1),(17,'Тумба','tumba.stl',2,6),(18,'Модель ТУР-10','modelTur-10.obj',2,7),(20,'Станок ЕТ300','et300.obj',2,2),(22,'ЦПР','cpr.obj',2,3),(23,'РФ','RF200.obj',2,6),(24,'Картинка Снайпер 8','sniper.png',4,1),(25,'Картинка ЕТ300','ET3000TI.jpg',4,2),(26,'Картинка ЦПР-1П','CPR-1P.jpg',4,3),(27,'Картинка РФ-202М','RR202-M.jpg',4,6),(28,'Картинка ТУР-10','img2tur.jpg',4,7),(29,'Картинка ТУР-10 2','TUR10.jpg',4,7),(30,'Картинка для компроссора','comp.jpg',4,8),(32,'Картинка 2 для Ет','img2et300.jpg',4,2),(33,'Картинка 3 для ет','img3et300.jpg',4,2),(34,'Картинка 3 для цпр','img3Cpr.jpg',4,3),(35,'Картинка 2 для цпр','imgCpr.jpg',4,3),(38,'Картинка для рф 2','imgRf.jpg',4,6),(39,'Картинка для рф 3','img2Rf.jpg',4,6);
/*!40000 ALTER TABLE `material` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-23 12:14:17
