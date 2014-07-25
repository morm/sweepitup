/*
SQLyog Professional v11.51 (64 bit)
MySQL - 5.6.14-log : Database - seepitup
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `garbage` */

CREATE TABLE `garbage` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `glass` int(11) DEFAULT NULL,
  `plastmass` int(11) DEFAULT NULL,
  `paper` int(11) DEFAULT NULL,
  `metall` int(11) DEFAULT NULL,
  `stones` int(11) DEFAULT NULL,
  `sorted` tinyint(1) DEFAULT NULL,
  `longitude` char(1) NOT NULL,
  `latitude` char(1) NOT NULL,
  `username` char(1) DEFAULT NULL,
  `email` char(1) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
