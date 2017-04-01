clc;
clear all;
close all;
x=imread('C:\Program Files\MATLAB\OMR4.jpg');
original=rgb2gray(x);
imshow(original);
x2=imread('C:\Program Files\MATLAB\OMR3.jpg');
distorted=rgb2gray(x2);
scale = 0.7;
J = imresize(original, scale); % Try varying the scale factor.
theta = 30;
distorted = imrotate(J,theta); % Try varying the angle, theta.
figure(2);
imshow(distorted);
ptsOriginal  = detectSURFFeatures(original);
ptsDistorted = detectSURFFeatures(distorted);
[featuresOriginal,   validPtsOriginal]  = extractFeatures(original,  ptsOriginal);
[featuresDistorted, validPtsDistorted]  = extractFeatures(distorted, ptsDistorted);
indexPairs = matchFeatures(featuresOriginal, featuresDistorted);
matchedOriginal  = validPtsOriginal(indexPairs(:,1));
matchedDistorted = validPtsDistorted(indexPairs(:,2));

sc = scale*cos(theta)
ss = scale*sin(theta)
Tinv = [sc -ss  0; ss  sc  0]
%Tinv  = invert(distorted);
ss = Tinv(2,1);
sc = Tinv(1,1);
scale_recovered = sqrt(ss*ss + sc*sc)
theta_recovered = atan2(ss,sc)*180/pi
outputView = imref2d(size(original));
recovered  = imwarp(distorted,tform,'OutputView',outputView);
figure(3);
imshow(recovered);