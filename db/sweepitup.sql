/*
SQLyog Professional v11.51 (64 bit)
MySQL - 5.6.14-log : Database - sweepitup
*********************************************************************
*/


/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `average_garbage` */

CREATE TABLE `average_garbage` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `glass` char(1)  NOT NULL DEFAULT 'N',
  `plastmass` char(1)  NOT NULL DEFAULT 'N',
  `paper` char(1)  NOT NULL DEFAULT 'N',
  `metall` char(1)  NOT NULL DEFAULT 'N',
  `stones` char(1)  NOT NULL DEFAULT 'N',
  `sorted` tinyint(1) DEFAULT 0,
  `longitude` double NOT NULL,
  `latitude` double NOT NULL,
  `username` text DEFAULT '',
  `email` text DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `garbage` */

CREATE TABLE `garbage` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `date` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
  `glass` char(1)  NOT NULL DEFAULT 'N',
  `plastmass` char(1)  NOT NULL DEFAULT 'N',
  `paper` char(1)  NOT NULL DEFAULT 'N',
  `metall` char(1)  NOT NULL DEFAULT 'N',
  `stones` char(1)  NOT NULL DEFAULT 'N',
  `sorted` tinyint(1) DEFAULT 0,
  `longitude` double NOT NULL,
  `latitude` double NOT NULL,
  `username` text DEFAULT '',
  `email` text DEFAULT '',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
