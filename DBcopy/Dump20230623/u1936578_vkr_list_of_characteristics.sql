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
-- Table structure for table `list_of_characteristics`
--

DROP TABLE IF EXISTS `list_of_characteristics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `list_of_characteristics` (
  `idcharacteristics` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(39) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`idcharacteristics`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `list_of_characteristics`
--

LOCK TABLES `list_of_characteristics` WRITE;
/*!40000 ALTER TABLE `list_of_characteristics` DISABLE KEYS */;
INSERT INTO `list_of_characteristics` VALUES (1,'Размеры рабочей поверхности стола'),(2,'Максимальный вес заготовки'),(3,'Привод'),(4,'Количество захватных устройств'),(5,'Cпособ программирования'),(6,'Объем оперативной памяти МКП, байт'),(7,'Габариты, мм'),(8,'Число степеней подвижности'),(9,'Масса станка, кг'),(10,'Производительность'),(11,'Энергопотребление'),(12,'Занимаемая площадь');
/*!40000 ALTER TABLE `list_of_characteristics` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-06-23 12:13:38
