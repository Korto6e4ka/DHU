/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50525
Source Host           : localhost:3306
Source Database       : dhu

Target Server Type    : MYSQL
Target Server Version : 50525
File Encoding         : 65001

Date: 2024-04-16 18:14:02
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for apartment
-- ----------------------------
DROP TABLE IF EXISTS `apartment`;
CREATE TABLE `apartment` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `apartment_number` int(11) DEFAULT NULL,
  `floor` int(255) DEFAULT NULL,
  `entrance` int(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of apartment
-- ----------------------------
INSERT INTO `apartment` VALUES ('1', '1', '1', '1');
INSERT INTO `apartment` VALUES ('2', '2', '1', '1');
INSERT INTO `apartment` VALUES ('3', '3', '1', '1');
INSERT INTO `apartment` VALUES ('4', '4', '1', '1');
INSERT INTO `apartment` VALUES ('5', '5', '1', '1');
INSERT INTO `apartment` VALUES ('6', '6', '2', '1');
INSERT INTO `apartment` VALUES ('7', '7', '2', '1');
INSERT INTO `apartment` VALUES ('8', '8', '2', '1');
INSERT INTO `apartment` VALUES ('9', '9', '2', '1');
INSERT INTO `apartment` VALUES ('10', '10', '3', '1');
INSERT INTO `apartment` VALUES ('11', '11', '3', '1');
INSERT INTO `apartment` VALUES ('12', '12', '3', '1');
INSERT INTO `apartment` VALUES ('13', '13', '3', '1');
INSERT INTO `apartment` VALUES ('14', '14', '3', '1');
INSERT INTO `apartment` VALUES ('15', '15', '3', '1');
INSERT INTO `apartment` VALUES ('16', '16', '1', '2');
INSERT INTO `apartment` VALUES ('17', '17', '1', '2');
INSERT INTO `apartment` VALUES ('18', '18', '1', '2');
INSERT INTO `apartment` VALUES ('19', '19', '1', '2');
INSERT INTO `apartment` VALUES ('20', '20', '1', '2');
INSERT INTO `apartment` VALUES ('21', '21', '2', '2');
INSERT INTO `apartment` VALUES ('22', '22', '2', '2');
INSERT INTO `apartment` VALUES ('23', '23', '2', '2');
INSERT INTO `apartment` VALUES ('24', '24', '2', '2');
INSERT INTO `apartment` VALUES ('25', '25', '2', '2');
INSERT INTO `apartment` VALUES ('26', '26', '3', '2');
INSERT INTO `apartment` VALUES ('27', '27', '3', '2');
INSERT INTO `apartment` VALUES ('28', '28', '3', '2');
INSERT INTO `apartment` VALUES ('29', '29', '3', '2');
INSERT INTO `apartment` VALUES ('30', '30', '3', '2');

-- ----------------------------
-- Table structure for authorization
-- ----------------------------
DROP TABLE IF EXISTS `authorization`;
CREATE TABLE `authorization` (
  `ID_worker` int(255) NOT NULL AUTO_INCREMENT,
  `Login` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  PRIMARY KEY (`ID_worker`,`Login`,`Password`),
  CONSTRAINT `Login` FOREIGN KEY (`ID_worker`) REFERENCES `workers utilities` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of authorization
-- ----------------------------
INSERT INTO `authorization` VALUES ('1', 'Buh123', 'qwer1234');
INSERT INTO `authorization` VALUES ('2', 'Buh456', 'asdf1234');
INSERT INTO `authorization` VALUES ('3', 'Glava123', 'zxcv1234');

-- ----------------------------
-- Table structure for electricity supply
-- ----------------------------
DROP TABLE IF EXISTS `electricity supply`;
CREATE TABLE `electricity supply` (
  `ID_apartment` int(255) NOT NULL DEFAULT '0',
  `day` int(255) DEFAULT NULL,
  `night` int(255) DEFAULT NULL,
  `general` int(255) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`ID_apartment`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of electricity supply
-- ----------------------------
INSERT INTO `electricity supply` VALUES ('2', '3135', '4267', '1353', '2024-04-09');
INSERT INTO `electricity supply` VALUES ('5', '2350', '4363', '2345', '2024-02-14');
INSERT INTO `electricity supply` VALUES ('10', '5600', '3464', '3531', '2023-11-17');
INSERT INTO `electricity supply` VALUES ('13', '1243', '5795', '1133', '2024-03-12');
INSERT INTO `electricity supply` VALUES ('14', '2530', '5735', '2354', '2024-03-12');
INSERT INTO `electricity supply` VALUES ('15', '2900', '806', '3525', '2024-02-29');
INSERT INTO `electricity supply` VALUES ('16', '1353', '4688', '1143', '2024-01-17');
INSERT INTO `electricity supply` VALUES ('22', '3467', '7897', '1323', '2024-02-21');
INSERT INTO `electricity supply` VALUES ('23', '5377', '2521', '4264', '2024-02-22');
INSERT INTO `electricity supply` VALUES ('26', '3467', '3532', '1345', '2024-03-12');
INSERT INTO `electricity supply` VALUES ('28', '3560', '4758', '3135', '2024-04-03');
INSERT INTO `electricity supply` VALUES ('30', '7500', '1536', '2351', '2023-12-21');

-- ----------------------------
-- Table structure for heat supply
-- ----------------------------
DROP TABLE IF EXISTS `heat supply`;
CREATE TABLE `heat supply` (
  `ID_apartment` int(255) NOT NULL,
  `dedt_amount` int(255) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`ID_apartment`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of heat supply
-- ----------------------------
INSERT INTO `heat supply` VALUES ('1', '2600', '2024-03-07');
INSERT INTO `heat supply` VALUES ('3', '1780', '2024-01-11');
INSERT INTO `heat supply` VALUES ('5', '2134', '2024-02-14');
INSERT INTO `heat supply` VALUES ('8', '5778', '2024-04-06');
INSERT INTO `heat supply` VALUES ('11', '6890', '2024-02-28');
INSERT INTO `heat supply` VALUES ('14', '4677', '2024-01-24');
INSERT INTO `heat supply` VALUES ('19', '7890', '2024-01-16');
INSERT INTO `heat supply` VALUES ('25', '4890', '2023-11-23');
INSERT INTO `heat supply` VALUES ('26', '4564', '2024-02-20');
INSERT INTO `heat supply` VALUES ('27', '5679', '2024-02-13');
INSERT INTO `heat supply` VALUES ('29', '3456', '2024-02-25');

-- ----------------------------
-- Table structure for water supply
-- ----------------------------
DROP TABLE IF EXISTS `water supply`;
CREATE TABLE `water supply` (
  `ID_apartment` int(255) NOT NULL,
  `hot` int(255) DEFAULT NULL,
  `cold` int(255) DEFAULT NULL,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`ID_apartment`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of water supply
-- ----------------------------
INSERT INTO `water supply` VALUES ('6', '5790', '1245', '2024-01-30');
INSERT INTO `water supply` VALUES ('9', '7859', '2335', '2024-03-14');
INSERT INTO `water supply` VALUES ('11', '6894', '6462', '2024-03-26');
INSERT INTO `water supply` VALUES ('16', '5790', '3125', '2023-12-20');
INSERT INTO `water supply` VALUES ('17', '5863', '6478', '2024-02-29');
INSERT INTO `water supply` VALUES ('18', '6584', '5236', '2024-03-20');
INSERT INTO `water supply` VALUES ('23', '2351', '3256', '2024-02-21');
INSERT INTO `water supply` VALUES ('24', '8657', '7437', '2024-03-20');
INSERT INTO `water supply` VALUES ('28', '4268', '2557', '2024-01-17');

-- ----------------------------
-- Table structure for workers utilities
-- ----------------------------
DROP TABLE IF EXISTS `workers utilities`;
CREATE TABLE `workers utilities` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Job_title` varchar(255) DEFAULT NULL,
  `Surname` varchar(255) DEFAULT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Father_name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of workers utilities
-- ----------------------------
INSERT INTO `workers utilities` VALUES ('1', 'Бухгалтер', 'Викторовна', 'Ольга', 'Стукова');
INSERT INTO `workers utilities` VALUES ('2', 'Бухгалтер', 'Сергеевна', 'Светлана', 'Уткова');
INSERT INTO `workers utilities` VALUES ('3', 'Главный директор', 'Маркович', 'Михаил', 'Клюев ');
SET FOREIGN_KEY_CHECKS=1;
