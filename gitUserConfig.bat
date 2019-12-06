@ECHO OFF

cd desktop
Start /w git clone https://github.com/Zeroclipse/Torchlight-Clone.git
cd torchlight-clone
git config --global user.name "Cody Wilcox"
git config --global user.email "cdwilcox1999@gmail.com"

@ECHO ON

cmd /K