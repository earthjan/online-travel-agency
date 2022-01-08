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
-- Table structure for table `billed_booked_flight_service`
--

DROP TABLE IF EXISTS `billed_booked_flight_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `billed_booked_flight_service` (
  `bill_ID` int NOT NULL AUTO_INCREMENT,
  `booking_ID` int NOT NULL,
  `method` varchar(45) NOT NULL,
  `total_price` decimal(20,2) NOT NULL,
  PRIMARY KEY (`bill_ID`),
  KEY `booking_ID` (`booking_ID`),
  CONSTRAINT `billed_booked_flight_service_ibfk_1` FOREIGN KEY (`booking_ID`) REFERENCES `booked_flight_service` (`booking_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `billed_booked_flight_service`
--

LOCK TABLES `billed_booked_flight_service` WRITE;
/*!40000 ALTER TABLE `billed_booked_flight_service` DISABLE KEYS */;
INSERT INTO `billed_booked_flight_service` VALUES (2,2,'Over the counter',14250.00),(3,3,'Over the counter',13250.00),(4,4,'Over the counter',14250.00),(5,5,'Over the counter',13250.00),(6,6,'Over the counter',14250.00),(7,7,'Over the counter',13250.00),(8,8,'Over the counter',13250.00),(9,9,'Over the counter',13250.00),(10,10,'Over the counter',19250.00),(11,11,'Over the counter',19250.00),(12,12,'Over the counter',19250.00),(13,13,'Over the counter',12250.00),(14,14,'Over the counter',16250.00),(15,15,'Over the counter',13250.00),(16,16,'Over the counter',14250.00),(17,17,'Over the counter',13250.00),(18,18,'Over the counter',13250.00);
/*!40000 ALTER TABLE `billed_booked_flight_service` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-01-09  5:22:03
