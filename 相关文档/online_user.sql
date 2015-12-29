/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1_3306
Source Server Version : 50547
Source Host           : 127.0.0.1:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50547
File Encoding         : 65001

Date: 2015-12-29 18:27:49
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
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of online_user
-- ----------------------------
