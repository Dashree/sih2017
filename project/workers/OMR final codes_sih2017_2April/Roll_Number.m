function [R_N] = Roll_Number(roll_no_segment)
[a, b]=size(roll_no_segment);

roll_no_segment=roll_no_segment(:,20:b-15);
roll_no_segment=[ones(a,2), roll_no_segment,ones(a,2) ];% first and last column of the segment must be one.

inv_img=~roll_no_segment;
[a, b]=size(inv_img);
Hr_Profile=sum(inv_img,1)./a;
 Vr_Profile=sum(inv_img,2)./b;
[a1, b1]=size(Hr_Profile);
for i=1:b1
 if Hr_Profile(1, i)>0.02
     Hr_Profile(1, i)=1;
 else Hr_Profile(1, i)=0;
 end
end
 
 [a2, b2]=size(Vr_Profile);
for i=1:a2
 if Vr_Profile(i)>0.02
     Vr_Profile(i)=1;
 else Vr_Profile(i)=0;
 end
end
x=Hr_Profile;
y=Vr_Profile;
dx=diff(x);
dy=diff(y);
z1=find(dx);
z2=find(dy);
no_questions=length(z2)/2;
no_options=length(z1)/2;


for i=0:no_questions-1
    k=2*i+1;
    for j=0:no_options-1
        p=2*j+1;
      z{i+1,j+1}=roll_no_segment(z2(k):z2(k+1), z1(p):z1(p+1));
    end
end

% obtain the percentage of number of black pixels in every segment
[rr, cc]=size(z);




for i=1:rr
    for j=1:cc
        im=z{i,j};
    cw = sum(im(:));
    cb = numel(im) - cw;
    black_percent{i, j}=(100*cb)/numel(im);
    if black_percent{i,j}>50
        black_percent{i,j}=1;
    else black_percent{i,j}=0;
    end
    end
end

ww=cell2mat(black_percent);
R_N=zeros(1,cc);
for j=1:cc
  R_N(j)=find(ww(:,j));
  if R_N(j)==10
      R_N(j)=0
  end
end

      
