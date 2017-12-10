-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	5.7.18-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `surname` varchar(60) NOT NULL,
  `telephone` varchar(60) NOT NULL,
  `date_of_birth` date NOT NULL,
  `place_of_birth` varchar(60) NOT NULL,
  `title` varchar(45) NOT NULL,
  `date_of_employment` date NOT NULL,
  `role_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_employee_role1_idx` (`role_id`),
  CONSTRAINT `fk_employee_role1` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee_subject`
--

DROP TABLE IF EXISTS `employee_subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee_subject` (
  `employee_id` int(11) NOT NULL,
  `subject_id` int(11) NOT NULL,
  PRIMARY KEY (`employee_id`,`subject_id`),
  KEY `fk_employee_has_subject_subject1_idx` (`subject_id`),
  KEY `fk_employee_has_subject_employee1_idx` (`employee_id`),
  CONSTRAINT `fk_employee_has_subject_employee1` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_employee_has_subject_subject1` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee_subject`
--

LOCK TABLES `employee_subject` WRITE;
/*!40000 ALTER TABLE `employee_subject` DISABLE KEYS */;
/*!40000 ALTER TABLE `employee_subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lecture`
--

DROP TABLE IF EXISTS `lecture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `lecture` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `subject_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_lecture_subject1_idx` (`subject_id`),
  CONSTRAINT `fk_lecture_subject1` FOREIGN KEY (`subject_id`) REFERENCES `subject` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lecture`
--

LOCK TABLES `lecture` WRITE;
/*!40000 ALTER TABLE `lecture` DISABLE KEYS */;
/*!40000 ALTER TABLE `lecture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `report`
--

DROP TABLE IF EXISTS `report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `report` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` date NOT NULL,
  `reporter` varchar(45) NOT NULL,
  `purpose` varchar(255) NOT NULL,
  `reportcol` varchar(45) NOT NULL,
  `employee_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_report_employee1_idx` (`employee_id`),
  CONSTRAINT `fk_report_employee1` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `report`
--

LOCK TABLES `report` WRITE;
/*!40000 ALTER TABLE `report` DISABLE KEYS */;
/*!40000 ALTER TABLE `report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `role_name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role`
--

LOCK TABLES `role` WRITE;
/*!40000 ALTER TABLE `role` DISABLE KEYS */;
INSERT INTO `role` VALUES (1,'student'),(2,'professor');
/*!40000 ALTER TABLE `role` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `salary`
--

DROP TABLE IF EXISTS `salary`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `salary` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `salary` int(11) NOT NULL,
  `employee_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_salary_employee1_idx` (`employee_id`),
  CONSTRAINT `fk_salary_employee1` FOREIGN KEY (`employee_id`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `salary`
--

LOCK TABLES `salary` WRITE;
/*!40000 ALTER TABLE `salary` DISABLE KEYS */;
/*!40000 ALTER TABLE `salary` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `year_of_study` int(11) NOT NULL,
  `degree` varchar(30) NOT NULL,
  `department` varchar(30) NOT NULL,
  `index_nuumber` varchar(30) NOT NULL,
  `date_of_birth` date NOT NULL,
  `place_of_birth` varchar(60) NOT NULL,
  `number_of_requests` int(11) DEFAULT NULL,
  `telephone` varchar(45) NOT NULL,
  `role_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_student_role1_idx` (`role_id`),
  CONSTRAINT `fk_student_role1` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=81 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES (1,'Sigvard',2017,'Bacheleor','RI','1392','1886-09-09','Citeureup',2,'908-803-7975',1),(2,'Robbie',2017,'Bacheleor','RI','1054','1898-12-16','Pantaibesar',3,'990-365-5422',1),(3,'Dukey',2016,'Bacheleor','RI','1077','1905-11-01','Gorgān',9,'623-868-8071',1),(4,'Pincas',2005,'Bacheleor','RI','1277','1922-04-05','Fenchen',6,'907-953-1808',1),(5,'Brewer',2008,'Bacheleor','RI','1458','1974-09-30','São Fidélis',0,'670-594-9092',1),(6,'Frank',2006,'Bacheleor','RI','1472','1916-09-04','Porto Salvo',9,'417-681-2225',1),(7,'Trueman',2010,'Bacheleor','RI','1468','1901-08-07','Kosonsoy',8,'121-617-0500',1),(8,'Gwyneth',2012,'Bacheleor','RI','1048','1917-06-26','Bagaces',2,'397-146-8853',1),(9,'Isadore',2011,'Bacheleor','RI','1499','1948-12-15','Rauma',1,'700-804-3553',1),(10,'Rockie',2006,'Bacheleor','RI','1453','1993-12-04','Baiguan',9,'882-750-7126',1),(11,'Izaak',2014,'Bacheleor','RI','1170','1921-09-04','Maythalūn',0,'824-521-1603',1),(12,'Odey',2010,'Bacheleor','RI','1368','1975-03-16','Yong’an',7,'462-613-9019',1),(13,'Jody',2015,'Bacheleor','RI','1335','1995-08-18','Paris La Défense',4,'579-988-4963',1),(14,'Germain',2013,'Bacheleor','RI','1072','1965-04-24','Yangjinzhuang',9,'431-290-7231',1),(15,'Rebeka',2008,'Bacheleor','RI','1348','1994-11-09','Kokhanava',10,'845-971-2147',1),(16,'Leisha',2005,'Bacheleor','RI','1331','1904-01-13','Gniezno',5,'142-565-8642',1),(17,'Felicia',2010,'Bacheleor','RI','1195','1993-03-27','Huicungo',4,'169-806-4805',1),(18,'Dexter',2012,'Bacheleor','RI','1201','1927-02-10','Agana Heights Village',9,'353-948-3303',1),(19,'Onfroi',2007,'Bacheleor','RI','1405','1941-10-25','Rivas',10,'668-619-6959',1),(20,'Valdemar',2015,'Bacheleor','RI','1365','1926-03-05','Slatina',3,'243-880-9520',1),(21,'Valencia',2009,'Bacheleor','RI','1375','1994-07-13','Aconibe',3,'609-773-0663',1),(22,'Wylma',2010,'Bacheleor','RI','1116','1942-10-12','El Obeid',7,'343-402-3574',1),(23,'Darline',2014,'Bacheleor','RI','1201','1956-06-17','Guli',10,'485-508-3407',1),(24,'Morris',2006,'Bacheleor','RI','1118','1925-08-08','Campor',9,'689-898-6282',1),(25,'Mack',2010,'Bacheleor','RI','1238','1904-08-22','San Ramón',4,'872-634-5993',1),(26,'Willow',2010,'Bacheleor','RI','1215','1900-04-26','Wiskitki',5,'147-322-4549',1),(27,'Georgiana',2008,'Bacheleor','RI','1360','1931-03-09','Tawen Aobao',5,'547-303-4817',1),(28,'Thomasa',2008,'Bacheleor','RI','1249','1900-01-23','Gunajaya',8,'994-633-8539',1),(29,'Trisha',2008,'Bacheleor','RI','1254','1921-11-09','Sambongmulyo',8,'822-364-7608',1),(30,'David',2010,'Bacheleor','RI','1321','1970-05-11','Washington',8,'202-228-8832',1),(31,'Paxton',2005,'Bacheleor','RI','1164','1901-01-29','Jingmao',6,'406-803-1464',1),(32,'Kimberlee',2017,'Bacheleor','RI','1100','1911-08-28','Kuala Lumpur',0,'601-811-2532',1),(33,'Gabriellia',2011,'Bacheleor','RI','1412','1938-10-08','Chociwel',1,'228-209-6781',1),(34,'Nata',2017,'Bacheleor','RI','1118','1939-10-09','Pisão',6,'423-465-0112',1),(35,'Renato',2006,'Bacheleor','RI','1481','1900-09-22','Vila Chã de Ourique',8,'440-403-5532',1),(36,'Farlee',2009,'Bacheleor','RI','1236','1931-04-27','Paranavaí',2,'514-703-6669',1),(37,'Rafaellle',2006,'Bacheleor','RI','1485','1931-02-14','Zhenqian',7,'546-155-4458',1),(38,'Chloette',2011,'Bacheleor','RI','1442','1897-03-11','Tessalit',2,'266-875-0585',1),(39,'Arin',2007,'Bacheleor','RI','1030','1887-03-27','Sufālat Samā’il',4,'354-567-4997',1),(40,'Maximilien',2006,'Bacheleor','RI','1186','1950-03-07','Chitral',2,'132-231-1762',1),(41,'Rianon',2010,'Master','RI','2310','1923-01-12','Valtimo',6,'738-427-1645',1),(42,'Mason',2014,'Master','RI','2448','1889-10-11','Qiaozi',4,'328-604-9209',1),(43,'Vanya',2011,'Master','RI','2176','1993-06-04','Bokani',7,'841-808-3406',1),(44,'Burr',2007,'Master','RI','2186','1898-03-31','Aimorés',7,'935-916-2891',1),(45,'Skipton',2017,'Master','RI','2033','1921-05-15','Maghār',5,'628-316-3049',1),(46,'Pren',2013,'Master','RI','2433','1979-10-09','Youfang',3,'298-695-2959',1),(47,'Rafael',2008,'Master','RI','2403','1936-12-11','Pancoran',9,'382-932-9419',1),(48,'Christean',2007,'Master','RI','2454','1939-09-16','Nagareyama',7,'912-787-7701',1),(49,'Raddy',2010,'Master','RI','2032','1954-04-16','Dearborn',10,'313-501-9010',1),(50,'Desirae',2012,'Master','RI','2488','1949-07-12','Birayang',8,'600-119-7987',1),(51,'Sella',2012,'Master','RI','2287','1968-06-04','Kotel',8,'277-252-3871',1),(52,'Gregoire',2006,'Master','RI','2485','1931-01-25','Malitubog',5,'694-498-5970',1),(53,'Elvis',2006,'Master','RI','2169','1991-04-11','Dahuaishu',7,'596-117-9018',1),(54,'Paula',2015,'Master','RI','2272','1910-09-26','Chikushino-shi',7,'727-208-0780',1),(55,'Shae',2005,'Master','RI','2023','1900-11-26','Lubbock',0,'806-806-9870',1),(56,'Pearl',2005,'Master','RI','2358','1959-03-29','Qiaobian',7,'544-110-2588',1),(57,'Bond',2012,'Master','RI','2169','1950-07-25','Moravská Třebová',7,'803-495-3589',1),(58,'Loralee',2010,'Master','RI','2079','1994-04-17','Jojoima',3,'447-473-7855',1),(59,'Borg',2017,'Master','RI','2134','1940-09-27','Neiva',6,'138-222-5231',1),(60,'Janene',2010,'Master','RI','2394','1890-02-26','Muchkapskiy',9,'618-624-2303',1),(61,'Nero',2017,'Master','RI','2112','1988-08-30','Huambalpa',7,'765-426-6219',1),(62,'Amalle',2014,'Master','RI','2067','1895-08-27','Plomárion',4,'436-170-8877',1),(63,'Almeria',2007,'Master','RI','2046','1948-02-19','Åtvidaberg',10,'230-620-6667',1),(64,'Dallis',2009,'Master','RI','2449','1991-04-19','Xiaozhi',4,'932-628-0333',1),(65,'Alexandr',2006,'Master','RI','2295','1995-07-09','Grudë-Fushë',2,'869-707-5289',1),(66,'Eolanda',2008,'Master','RI','2317','1899-09-22','Ladário',2,'160-191-3795',1),(67,'Rania',2005,'Master','RI','2218','1962-06-13','Mirovice',10,'945-676-7170',1),(68,'Rodd',2013,'Master','RI','2074','1945-01-27','Daruoyan',1,'211-997-7480',1),(69,'Riccardo',2013,'Master','RI','2257','1950-06-08','José de Freitas',9,'384-182-7469',1),(70,'Laurens',2006,'Master','RI','2129','1886-12-27','Miaoqian',9,'804-497-2775',1),(71,'Enrichetta',2008,'Master','RI','2357','1992-10-14','Kavieng',0,'601-957-5571',1),(72,'Charlotta',2010,'Master','RI','2184','1970-02-25','Sumurnanjung',6,'789-548-4484',1),(73,'Ambrosi',2016,'Master','RI','2117','1969-08-19','Oliveira de Frades',10,'985-489-8463',1),(74,'Peyter',2014,'Master','RI','2061','1886-02-15','Negararatu',10,'188-432-7596',1),(75,'Daven',2007,'Master','RI','2191','1997-03-17','Thetford-Mines',10,'101-209-6346',1),(76,'Shannon',2008,'Master','RI','2005','1915-02-10','Tanshan',8,'800-329-0198',1),(77,'Ephrem',2016,'Master','RI','2232','1885-03-20','Chengxi',8,'731-504-0445',1),(78,'Harmonia',2013,'Master','RI','2239','1989-12-27','San Jorge',6,'629-221-2913',1),(79,'Rinaldo',2013,'Master','RI','2357','1976-11-14','Laowobao',8,'285-436-7658',1),(80,'Hendrik',2006,'Master','RI','2037','1983-05-25','Fort Liberté',3,'731-906-0316',1);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_lecture`
--

DROP TABLE IF EXISTS `student_lecture`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student_lecture` (
  `student_id` int(11) NOT NULL,
  `lecture_id` int(11) NOT NULL,
  `attendance` tinyint(4) NOT NULL,
  PRIMARY KEY (`student_id`,`lecture_id`),
  KEY `fk_student_has_lecture_lecture1_idx` (`lecture_id`),
  KEY `fk_student_has_lecture_student1_idx` (`student_id`),
  CONSTRAINT `fk_student_has_lecture_lecture1` FOREIGN KEY (`lecture_id`) REFERENCES `lecture` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_student_has_lecture_student1` FOREIGN KEY (`student_id`) REFERENCES `student` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_lecture`
--

LOCK TABLES `student_lecture` WRITE;
/*!40000 ALTER TABLE `student_lecture` DISABLE KEYS */;
/*!40000 ALTER TABLE `student_lecture` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subject`
--

DROP TABLE IF EXISTS `subject`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subject` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `description` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subject`
--

LOCK TABLES `subject` WRITE;
/*!40000 ALTER TABLE `subject` DISABLE KEYS */;
/*!40000 ALTER TABLE `subject` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `password` varchar(60) NOT NULL,
  `email` varchar(100) NOT NULL,
  `role_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`role_id`),
  KEY `fk_user_role_idx` (`role_id`),
  CONSTRAINT `fk_user_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'sumejja','sumejja','sumejja@gmail.com',1);
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-10  1:26:19
