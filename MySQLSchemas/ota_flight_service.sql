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
-- Table structure for table `flight_service`
--

DROP TABLE IF EXISTS `flight_service`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `flight_service` (
  `FS_ID` int NOT NULL AUTO_INCREMENT,
  `airline_code` int NOT NULL,
  `price` decimal(8,2) NOT NULL,
  `duration` varchar(45) NOT NULL,
  `departure_schedule` varchar(45) NOT NULL,
  `arrival_schedule` varchar(45) NOT NULL,
  `Origin` varchar(45) NOT NULL,
  `Destination` varchar(45) NOT NULL,
  `flight_number` varchar(45) NOT NULL,
  `fare_type` varchar(45) NOT NULL,
  `cabin_class` varchar(45) NOT NULL,
  `trip_type` varchar(45) NOT NULL,
  `no_of_booked_passengers` int NOT NULL,
  `max_passengers` int NOT NULL,
  PRIMARY KEY (`FS_ID`),
  KEY `airline_code` (`airline_code`),
  CONSTRAINT `flight_service_ibfk_1` FOREIGN KEY (`airline_code`) REFERENCES `airline` (`airline_code`)
) ENGINE=InnoDB AUTO_INCREMENT=667 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `flight_service`
--

LOCK TABLES `flight_service` WRITE;
/*!40000 ALTER TABLE `flight_service` DISABLE KEYS */;
INSERT INTO `flight_service` VALUES (1,15,10000.00,'00hr','depart_sched_test_1','arrival_sched_test_1','origin_test_7','destination_test_7','flight_number_test_7','fare_type_test_7','Economy','Return',99,100),(2,14,10000.00,'00hr','depart_sched_test_2','arrival_sched_test_2','origin_test_8','destination_test_8','flight_number_test_8','fare_type_test_8','Economy','Return',100,100),(3,5,10000.00,'00hr','depart_sched_test_3','arrival_sched_test_3','origin_test_9','destination_test_9','flight_number_test_9','fare_type_test_9','Economy','Return',0,100),(4,0,10000.00,'00hr','depart_sched_test_4','arrival_sched_test_4','origin_test_10','destination_test_10','flight_number_test_10','fare_type_test_10','Economy','Return',0,100),(5,1,10000.00,'00hr','depart_sched_test_5','arrival_sched_test_5','origin_test_11','destination_test_11','flight_number_test_11','fare_type_test_11','Economy','Return',0,100),(6,6,10000.00,'00hr','depart_sched_test_6','arrival_sched_test_6','origin_test_12','destination_test_12','flight_number_test_12','fare_type_test_12','Economy','Return',0,100),(7,2,10000.00,'00hr','depart_sched_test_7','arrival_sched_test_7','origin_test_13','destination_test_13','flight_number_test_13','fare_type_test_13','Economy','Return',0,100),(8,3,10000.00,'00hr','depart_sched_test_8','arrival_sched_test_8','origin_test_14','destination_test_14','flight_number_test_14','fare_type_test_14','Economy','Return',0,100),(9,4,10000.00,'00hr','depart_sched_test_9','arrival_sched_test_9','origin_test_15','destination_test_15','flight_number_test_15','fare_type_test_15','Economy','Return',0,100),(10,2,10000.00,'00hr','depart_sched_test_10','arrival_sched_test_10','origin_test_16','destination_test_16','flight_number_test_16','fare_type_test_16','Economy','Return',0,100),(11,11,10000.00,'00hr','depart_sched_test_11','arrival_sched_test_11','origin_test_17','destination_test_17','flight_number_test_17','fare_type_test_17','Economy','Return',0,100),(12,12,10000.00,'00hr','depart_sched_test_12','arrival_sched_test_12','origin_test_18','destination_test_18','flight_number_test_18','fare_type_test_18','Economy','Return',0,100),(13,16,10000.00,'00hr','depart_sched_test_13','arrival_sched_test_13','origin_test_19','destination_test_19','flight_number_test_19','fare_type_test_19','Economy','Return',0,100),(14,14,10000.00,'00hr','depart_sched_test_14','arrival_sched_test_14','origin_test_20','destination_test_20','flight_number_test_20','fare_type_test_20','Economy','Return',0,100),(15,12,10000.00,'00hr','depart_sched_test_15','arrival_sched_test_15','origin_test_21','destination_test_21','flight_number_test_21','fare_type_test_21','Economy','Return',0,100),(16,2,10000.00,'00hr','depart_sched_test_16','arrival_sched_test_16','origin_test_22','destination_test_22','flight_number_test_22','fare_type_test_22','Economy','Return',0,100),(17,3,10000.00,'00hr','depart_sched_test_17','arrival_sched_test_17','origin_test_23','destination_test_23','flight_number_test_23','fare_type_test_23','Economy','Return',0,100),(18,4,10000.00,'00hr','depart_sched_test_18','arrival_sched_test_18','origin_test_24','destination_test_24','flight_number_test_24','fare_type_test_24','Economy','Return',0,100),(19,0,10000.00,'00hr','depart_sched_test_19','arrival_sched_test_19','origin_test_25','destination_test_25','flight_number_test_25','fare_type_test_25','Economy','Return',0,100),(20,0,10000.00,'00hr','depart_sched_test_20','arrival_sched_test_20','origin_test_26','destination_test_26','flight_number_test_26','fare_type_test_26','Economy','Return',0,100),(21,1,10000.00,'00hr','depart_sched_test_21','arrival_sched_test_21','origin_test_27','destination_test_27','flight_number_test_27','fare_type_test_27','Economy','Return',0,100),(22,6,10000.00,'00hr','depart_sched_test_22','arrival_sched_test_22','origin_test_28','destination_test_28','flight_number_test_28','fare_type_test_28','Economy','Return',0,100),(23,15,10000.00,'00hr','depart_sched_test_23','arrival_sched_test_23','origin_test_29','destination_test_29','flight_number_test_29','fare_type_test_29','Economy','Return',0,100),(24,16,10000.00,'00hr','depart_sched_test_24','arrival_sched_test_24','origin_test_30','destination_test_30','flight_number_test_30','fare_type_test_30','Economy','Return',99,100),(25,5,10000.00,'00hr','depart_sched_test_25','arrival_sched_test_25','origin_test_31','destination_test_31','flight_number_test_31','fare_type_test_31','Economy','Return',95,100),(26,0,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_6','destination_test_6','flight_number_test_6','fare_type_test_6','Economy','Return',0,100),(27,12,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_7','destination_test_7','flight_number_test_6','fare_type_test_6','Economy','Return',0,100),(28,1,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_7','destination_test_7','flight_number_test_6','fare_type_test_6','Economy','Return',0,100),(29,12,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_9','destination_test_9','flight_number_test_6','fare_type_test_6','Economy','Return',0,100),(30,5,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_9','destination_test_9','flight_number_test_6','fare_type_test_6','Economy','Return',0,100),(111,1,10000.00,'00hr','depart_sched_test_26','arrival_sched_test_26','origin_test_1','destination_test_1','flight_number_test_1','fare_type_test_1','Economy','Return',0,100),(222,1,10000.00,'00hr','depart_sched_test_27','arrival_sched_test_27','origin_test_2','destination_test_2','flight_number_test_2','fare_type_test_2','Economy','Return',0,100),(333,1,10000.00,'00hr','depart_sched_test_28','arrival_sched_test_28','origin_test_3','destination_test_3','flight_number_test_3','fare_type_test_3','Economy','Return',0,100),(444,0,10000.00,'00hr','depart_sched_test_29','arrival_sched_test_29','origin_test_4','destination_test_4','flight_number_test_4','fare_type_test_4','Economy','Return',0,100),(555,0,10000.00,'00hr','depart_sched_test_30','arrival_sched_test_30','origin_test_5','destination_test_5','flight_number_test_5','fare_type_test_5','Economy','Return',0,100),(666,0,10000.00,'00hr','depart_sched_test_31','arrival_sched_test_31','origin_test_6','destination_test_6','flight_number_test_6','fare_type_test_6','Economy','Return',0,100);
/*!40000 ALTER TABLE `flight_service` ENABLE KEYS */;
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
