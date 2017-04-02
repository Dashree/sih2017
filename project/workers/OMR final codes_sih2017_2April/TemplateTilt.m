 % EXAMPLE: Recover a transformed image using SURF feature points
    % --------------------------------------------------------------
    Iin  = rgb2gray(imread('C:\x-gen\OMR final codes_Revised\Master1.jpg')); imshow(Iin); title('Base image');
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
 