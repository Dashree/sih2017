function [column] = Answer_Columns(Answer_segment)
% This function returens column as segmented number of columns of the
% answer segments
% inv_img=~Answer_segment;
% [a, b]=size(inv_img);
% Hr_Profile=sum(inv_img,1)./a;

BW_edge = edge(Answer_segment);
BW_edge=medfilt2(BW_edge);

[a b]=size(BW_edge);
se = strel('line',5,90);
BWH = imdilate(BW_edge,se);
Hr_Profile=sum(BWH,1)./max(sum(BWH,1));
 
[a1, b1]=size(Hr_Profile);
for i=1:b1
 if Hr_Profile(1, i)>0.42
     Hr_Profile(1, i)=1;
 else Hr_Profile(1, i)=0;
 end
end
 
 
x=Hr_Profile;

dx=diff(x);

z1=find(dx);

no_columns=(length(z1)/2+1);

column{1}=Answer_segment(:, 5:z1(1)-20);
column{2}=Answer_segment(:, z1(2)+25:z1(3)-45);
column{3}=Answer_segment(:, z1(4)+25:z1(5)-45);
column{4}=Answer_segment(:, z1(6)+25:b);



