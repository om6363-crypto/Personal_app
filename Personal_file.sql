show search_path;

drop table personal_info;

create table Personal_info (
	id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    dob DATE NOT NULL,
    residential_address TEXT NOT NULL,
    permanent_address TEXT NOT NULL,
    phone_number VARCHAR(15) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    marital_status VARCHAR(50),
    gender VARCHAR(10),
    occupation VARCHAR(100),
    aadhar_card VARCHAR(12) UNIQUE,
    pan_card VARCHAR(10) UNIQUE,
    image varchar(100)
);

INSERT INTO Personal_info (name, dob, residential_address, permanent_address, phone_number, email, marital_status, gender, occupation, aadhar_card, pan_card, image) VALUES
('Amit Sharma', '1985-05-15', '123 MG Road, Borivali, Maharashtra', '456 SV Road, Borivali, Maharashtra', '9876543210', 'amit.sharma@example.com', 'Single', 'Male', 'Software Engineer', '123456789012', 'ABCDE1234F', 'static/image/amit_sharma.jpg'),
('Priya Singh', '1990-08-25', '789 LBS Road, Borivali, Maharashtra', '101 JVPD Scheme, Borivali, Maharashtra', '9876543211', 'priya.singh@example.com', 'Married', 'Female', 'Doctor', '234567890123', 'BCDEF2345G', 'static/image/priya_singh.jpg'),
('Rahul Verma', '1978-12-10', '102 Linking Road, Borivali, Maharashtra', '203 Carter Road, Borivali, Maharashtra', '9876543212', 'rahul.verma@example.com', 'Married', 'Male', 'Teacher', '345678901234', 'CDEFG3456H', 'static/image/rahul_verma.jpg'),
('Anjali Mehta', '1982-03-22', '304 Hill Road, Borivali, Maharashtra', '405 Turner Road, Borivali, Maharashtra', '9876543213', 'anjali.mehta@example.com', 'Single', 'Female', 'Lawyer', '456789012345', 'DEFGH4567I', 'static/image/anjali_mehta.jpg'),
('Vikram Patel', '1995-07-30', '506 SVP Road, Borivali, Maharashtra', '607 Nepean Sea Road, Borivali, Maharashtra', '9876543214', 'vikram.patel@example.com', 'Single', 'Male', 'Accountant', '567890123456', 'EFGHI5678J', 'static/image/vikram_patel.jpg');

select * from Personal_info;