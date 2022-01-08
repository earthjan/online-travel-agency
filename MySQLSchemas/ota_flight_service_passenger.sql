-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: localhost    Database: ota
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `flight_service_passenger`
--

DROP TABLE IF EXISTS `flight_service_passenger`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `flight_service_passenger` (
  `passenger_ID` int NOT NULL AUTO_INCREMENT,
  `given_name` varchar(55) NOT NULL,
  `middle_name` varchar(45) NOT NULL,
  `surname` varchar(45) NOT NULL,
  `gender` varchar(6) NOT NULL,
  `birthdate` varchar(55) NOT NULL,
  `passport_or_ID_no` varchar(45) NOT NULL,
  `passport_or_ID_expiry_date` varchar(45) NOT NULL,
  `email` varchar(55) NOT NULL,
  `mobile_no` varchar(45) NOT NULL,
  PRIMARY KEY (`passenger_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=935491 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flight_service_passenger`
--

LOCK TABLES `flight_service_passenger` WRITE;
/*!40000 ALTER TABLE `flight_service_passenger` DISABLE KEYS */;
INSERT INTO `flight_service_passenger` VALUES (156841,'test1','NA','test1','Male','2022-01-08','111','2022-01-08','garenmarzan@gmail.com','09062650647'),(165764,'Casper','NA','Marzan','Male','2022-01-08','222','2022-01-08','garenmarzan@gmail.com','09062650647'),(392592,'test1','NA','test1','Male','2022-01-07','111','2022-01-07','garenmarzan@gmail.com','09062650647'),(415488,'test','NA','test','Male','2000-01-17','123','2021-12-23','garenmarzan@gmail.com','09062650647'),(470770,'Creamy','NA','Marzan','Male','2022-01-08','111','2022-01-08','garenmarzan@gmail.com','09062650647'),(596124,'test','NA','test','Male','2000-01-17','123','2021-12-23','garenmarzan@gmail.com','09062650647'),(679334,'asdf','NA','sdsadf','Male','2021-02-18','21342134','2021-02-26','aDAsdf@gas.co','2342'),(696605,'123','NA','123','Male','2022-01-08','111','2022-01-08','garenmarzan@gmail.com','09062650647'),(769935,'test2','NA','test2','Male','2022-01-08','222','2022-01-08','garenmarzan@gmail.com','09062650647'),(899983,'test','NA','test','Male','2021-12-22','123','2021-12-24','garenmarzan@gmail.com','09062650647'),(935486,'test1','NA','test1','Male','2022-01-08','111','2022-01-08','garenmarzan@gmail.com','09062650647'),(935487,'goku','NA','goku','Male','2022-01-08','123','2022-01-08','garenmarzan@gmail.com','09062650647'),(935488,'goku again','NA','goku again','Male','2022-01-08','123','2022-01-08','garenmarzan@gmail.com','09062650647'),(935489,'test','NA','test','Male','2022-01-09','12321','2022-01-09','garenmarzangmail.com','09062650647'),(935490,'sad','NA','adsf','Male','2022-01-09','123','2022-01-09','garenmarzan@gmail.com','09062650647');
/*!40000 ALTER TABLE `flight_service_passenger` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-09  5:22:04
