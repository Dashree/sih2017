clc;
clear all;
close all;

x=imread('C:\x-gen\OMR_Templates\TEMPLATE 11\NewStudent1.jpg');
x1=rgb2gray(x);
%imshow(x1);
x1_level=graythresh(x1);
BW = im2bw(x1,x1_level);
impixelinfo(BW);
boundaries=bwboundaries(BW);

x2=imread('C:\x-gen\OMR_Templates\TEMPLATE 11\NewStudent2.jpg');
x21=rgb2gray(x2);
%imshow(x1);
x21_level=graythresh(x21);
BW1 = im2bw(x21,x21_level);
BW2=imrotate(BW1,20);
boundaries1=bwboundaries(BW2);
%C=equate(boundaries,boundaries1);
%C=setdiff(boundaries,boundaries1);
C=isequal(boundaries,boundaries1);
display(C);
if(C==0)
    display('Continue!');
else
    display('Perform tilt operation');
     % EXAMPLE: Recover a transformed image using SURF feature points
    % --------------------------------------------------------------
    Iin  = rgb2gray(imread('C:\x-gen\OMR_Templates\TEMPLATE 11\Master1.jpg')); imshow(Iin); title('Base image');
    Iout = imresize(Iin, 0.7); Iout = imrotate(Iout, 31);
    figure; imshow(Iout); title('Transformed image');
   
    % Detect and extract features from both images
    ptsIn  = detectSURFFeatures(Iin);
    ptsOut = detectSURFFeatures(Iout);
    [featuresIn,   validPtsIn] = extractFeatures(Iin,  ptsIn);
    [featuresOut, validPtsOut] = extractFeatures(Iout, ptsOut);
   
    % Match feature vectors
    index_pairs = matchFeatures(featuresIn, featuresOut);
    matchedPtsIn  = validPtsIn(index_pairs(:,1));
    matchedPtsOut = validPtsOut(index_pairs(:,2));
    figure; showMatchedFeatures(Iin,Iout,matchedPtsIn,matchedPtsOut);
    title('Matched SURF points, including outliers');
   
    % Exclude the outliers and compute the transformation matrix
    [tform,inlierPtsOut,inlierPtsIn] = estimateGeometricTransform(matchedPtsOut,matchedPtsIn,'similarity');
    figure; showMatchedFeatures(Iin,Iout,inlierPtsIn,inlierPtsOut);
    title('Matched inlier points');
   
    % Recover the original image Iin from Iout
    outputView = imref2d(size(Iin));
    Ir = imwarp(Iout, tform, 'OutputView', outputView);
    figure; imshow(Ir); title('Recovered image');
 
end


     