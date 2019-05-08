#!/bin/bash
#Creating test users with FTP

#Password to set for the new users
password=SOMEPASSWORD!

#Info to create cert
country=DK
state=State
locality=City
organization=example.com
organizationalunit=IT
email=admin@example.com
commonname=example.com

#Create firewall rules
sudo ufw allow 20/tcp
sudo ufw allow 21/tcp
sudo ufw allow 990/tcp
sudo ufw allow 40000:50000/tcp

#Install vsftpd
sudo apt-get update
sudo apt-get install vsftpd -y
sudo cp /etc/vsftpd.conf /etc/vsftpd.conf.orig

#Reads userlist.txt - userlist.txt should contain the new usernames separated by newline
for USER in $(cat userlist.txt)
do

#Create new user
echo Creating new user: $USER
echo Setting password $password
sudo adduser $USER --gecos "First Last,RoomNumber,WorkPhone,HomePhone" --disabled-password
echo "$USER:$password" | sudo chpasswd

#Create FTP folder
sudo mkdir /home/$USER/ftp
sudo chown nobody:nogroup /home/$USER/ftp
sudo chmod a-w /home/$USER/ftp

#Create file folder
sudo mkdir /home/$USER/ftp/files
sudo chown $USER:$USER /home/$USER/ftp/files

#Add user to FTP userlist
echo "$USER" | sudo tee -a /etc/vsftpd.userlist

done

#Configuring FTP Access
sudo sed -i 's/.*write_enable.*/write_enable=YES/' /etc/vsftpd.conf
sudo sed -i 's/.*chroot_local_user.*/chroot_local_user=YES/' /etc/vsftpd.conf
sudo sed -i 's/.*write_enable.*/write_enable=YES/' /etc/vsftpd.conf

sudo grep -qxF 'user_sub_token=$USER' /etc/vsftpd.conf || echo 'user_sub_token=$USER' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'local_root=/home/$USER/ftp' /etc/vsftpd.conf || echo 'local_root=/home/$USER/ftp' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'pasv_min_port=40000' /etc/vsftpd.conf || echo 'pasv_min_port=40000' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'pasv_max_port=50000' /etc/vsftpd.conf || echo 'pasv_max_port=50000' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'userlist_enable=YES' /etc/vsftpd.conf || echo 'userlist_enable=YES' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'userlist_file=/etc/vsftpd.userlist' /etc/vsftpd.conf || echo 'userlist_file=/etc/vsftpd.userlist' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'userlist_deny=NO' /etc/vsftpd.conf || echo 'userlist_deny=NO' | sudo tee -a /etc/vsftpd.conf

#Securing FTP server
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/private/vsftpd.pem -out /etc/ssl/private/vsftpd.pem -subj "/C=$country/ST=$state/L=$locality/O=$organization/OU=$organizationalunit/CN=$commonname/emailAddress=$email"

sudo sed -i 's/.*rsa_cert_file.*/rsa_cert_file=\/etc\/ssl\/private\/vsftpd.pem/' /etc/vsftpd.conf
sudo sed -i 's/.*rsa_private_key_file.*/rsa_private_key_file=\/etc\/ssl\/private\/vsftpd.pem/' /etc/vsftpd.conf
sudo sed -i 's/.*ssl_enable.*/ssl_enable=YES/' /etc/vsftpd.conf

sudo grep -qxF 'allow_anon_ssl=NO' /etc/vsftpd.conf || echo 'allow_anon_ssl=NO' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'force_local_data_ssl=YES' /etc/vsftpd.conf || echo 'force_local_data_ssl=YES' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'force_local_logins_ssl=YES' /etc/vsftpd.conf || echo 'force_local_logins_ssl=YES' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'ssl_tlsv1=YES' /etc/vsftpd.conf || echo 'ssl_tlsv1=YES' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'ssl_sslv2=NO' /etc/vsftpd.conf || echo 'ssl_sslv2=NO' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'ssl_sslv3=NO' /etc/vsftpd.conf || echo 'ssl_sslv3=NO' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'require_ssl_reuse=NO' /etc/vsftpd.conf || echo 'require_ssl_reuse=NO' | sudo tee -a /etc/vsftpd.conf
sudo grep -qxF 'ssl_ciphers=HIGH' /etc/vsftpd.conf || echo 'ssl_ciphers=HIGH' | sudo tee -a /etc/vsftpd.conf

sudo systemctl restart vsftpd
