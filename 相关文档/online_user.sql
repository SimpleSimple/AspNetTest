/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1_3306
Source Server Version : 50547
Source Host           : 127.0.0.1:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50547
File Encoding         : 65001

Date: 2015-12-31 18:00:14
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for online_user
-- ----------------------------
DROP TABLE IF EXISTS `online_user`;
CREATE TABLE `online_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `signin_time` datetime DEFAULT NULL,
  `signout_time` datetime DEFAULT NULL,
  `create_time` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of online_user
-- ----------------------------
INSERT INTO `online_user` VALUES ('1', '1680001', '2015-12-29 17:36:14', '2015-12-29 18:36:14', '2015-12-29 18:36:14');
INSERT INTO `online_user` VALUES ('2', '1680002', '2015-12-29 17:36:14', '2015-12-29 18:36:14', '2015-12-29 18:36:14');
INSERT INTO `online_user` VALUES ('3', '1680003', '2015-12-29 17:36:14', '2015-12-29 18:36:14', '2015-12-29 18:36:14');
INSERT INTO `online_user` VALUES ('4', '1680004', '2015-12-29 17:36:14', '2015-12-29 18:36:14', '2015-12-29 18:36:14');
INSERT INTO `online_user` VALUES ('5', '1680005', '2015-12-29 17:36:14', '2015-12-29 18:36:14', '2015-12-29 18:36:14');
INSERT INTO `online_user` VALUES ('6', '1680002', '2015-12-30 08:55:31', '2015-12-30 09:55:31', '2015-12-30 09:55:31');
INSERT INTO `online_user` VALUES ('7', '1680003', '2015-12-30 08:37:13', '2015-12-30 09:59:13', '2015-12-30 09:59:13');
INSERT INTO `online_user` VALUES ('8', '1680004', '2015-12-30 08:23:13', '2015-12-30 09:59:13', '2015-12-30 09:59:13');
INSERT INTO `online_user` VALUES ('9', '1680005', '2015-12-30 08:17:13', '2015-12-30 09:59:13', '2015-12-30 09:59:13');
INSERT INTO `online_user` VALUES ('10', '1680006', '2015-12-30 08:21:13', '2015-12-30 09:59:13', '2015-12-30 09:59:13');
INSERT INTO `online_user` VALUES ('11', '1680007', '2015-12-30 08:47:13', '2015-12-30 09:59:13', '2015-12-30 09:59:13');
INSERT INTO `online_user` VALUES ('12', '1680008', '2015-12-30 18:12:57', '2015-12-30 19:34:57', '2015-12-30 19:34:57');
INSERT INTO `online_user` VALUES ('13', '1680009', '2015-12-30 17:58:57', '2015-12-30 19:34:57', '2015-12-30 19:34:57');
INSERT INTO `online_user` VALUES ('14', '1680010', '2015-12-30 17:52:57', '2015-12-30 19:34:57', '2015-12-30 19:34:57');
INSERT INTO `online_user` VALUES ('15', '1680011', '2015-12-30 17:56:57', '2015-12-30 19:34:57', '2015-12-30 19:34:57');
INSERT INTO `online_user` VALUES ('16', '1680012', '2015-12-30 18:22:57', '2015-12-30 19:34:57', '2015-12-30 19:34:57');
INSERT INTO `online_user` VALUES ('17', '1680019', '2015-12-31 14:57:29', null, '2015-12-31 15:18:29');
INSERT INTO `online_user` VALUES ('18', '1680020', '2015-12-31 15:05:29', null, '2015-12-31 15:18:29');
INSERT INTO `online_user` VALUES ('19', '1680021', '2015-12-31 15:12:29', null, '2015-12-31 15:18:29');
INSERT INTO `online_user` VALUES ('20', '1680021', '2015-12-31 15:12:29', null, '2015-12-31 15:18:29');
INSERT INTO `online_user` VALUES ('21', '1680022', '2015-12-31 15:12:29', null, '2015-12-31 15:18:29');
