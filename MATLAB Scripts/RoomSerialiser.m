%% Setup
clear;clc;

%% Initial

room = '1';
filePath = strcat('Room', room, '/');

% Starting string construction
JSONstr = '{';
JSONstr = strcat(JSONstr, '"ID":"room_1",');
JSONstr = strcat(JSONstr, '"height":16,');
JSONstr = strcat(JSONstr, '"width":32,');

%% Reading from images
JSONstr = strcat(JSONstr, '"floorPositions":', FileReader('floor_', room, filePath, 1), ',');
JSONstr = strcat(JSONstr, '"wallPositions":', FileReader('walls_', room, filePath, 0));

%% Finalising
JSONstr = strcat(JSONstr, '}');
disp(JSONstr);