@ECHO OFF

cd desktop
cmd /Wait git clone https://github.com/Zeroclipse/Torchlight-Clone.git
cd torchlight-clone
git config --global user.name "Cody Wilcox"
git config --global user.email "cdwilcox1999@gmail.com"

cmd /K
PAUSE