-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 09-06-2023 a las 00:01:56
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `theonlypath`
--
CREATE DATABASE IF NOT EXISTS `theonlypath` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `theonlypath`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `account`
--

CREATE TABLE `account` (
  `username` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL,
  `admin` varchar(1) NOT NULL DEFAULT 'n'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `account`
--

INSERT INTO `account` (`username`, `password`, `admin`) VALUES
('admin', 'admin', 'y'),
('rafa', '123', 'y'),
('rafaaa', '123', 'n');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `playedtime`
--

CREATE TABLE `playedtime` (
  `username` varchar(30) NOT NULL,
  `playedtime` time NOT NULL DEFAULT '00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `playedtime`
--

INSERT INTO `playedtime` (`username`, `playedtime`) VALUES
('admin', '00:00:00'),
('rafa', '00:28:31'),
('rafaaa', '00:04:16');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `position`
--

CREATE TABLE `position` (
  `username` varchar(30) NOT NULL,
  `posX` varchar(30) NOT NULL,
  `posY` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `position`
--

INSERT INTO `position` (`username`, `posX`, `posY`) VALUES
('admin', '0', '0'),
('rafa', '29', '25'),
('rafaaa', '-2', '2');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`username`);

--
-- Indices de la tabla `playedtime`
--
ALTER TABLE `playedtime`
  ADD PRIMARY KEY (`username`);

--
-- Indices de la tabla `position`
--
ALTER TABLE `position`
  ADD PRIMARY KEY (`username`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `playedtime`
--
ALTER TABLE `playedtime`
  ADD CONSTRAINT `account_playedtime` FOREIGN KEY (`username`) REFERENCES `account` (`username`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `position`
--
ALTER TABLE `position`
  ADD CONSTRAINT `position_ibfk_1` FOREIGN KEY (`username`) REFERENCES `account` (`username`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
