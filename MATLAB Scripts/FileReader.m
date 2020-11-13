function[JSONstr] = FileReader(part, roomID, filePath, oneorzero)

img = imread(strcat(filePath, part, roomID, '.png'));
figure;
imshow(img * 255)
JSONstr = '[';
for i = 1:size(img, 1)
    for j = 1:size(img, 2)
        if img(i, j) == oneorzero
            JSONstr = strcat(JSONstr, '[', num2str(i - 1), ...
            ',', num2str(j - 1), '],');
        end
    end
end
JSONstr = strip(JSONstr, 'right', ','); % Removing the last comma
JSONstr = strcat(JSONstr, ']');

end