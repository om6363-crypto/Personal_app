import React, { useState } from 'react';
import axios from 'axios';

const PostEntry = () => {
    const [formData, setFormData] = useState({
        name: '',
        dateOfBirth: '',
        residentialAddress: '',
        permanentAddress: '',
        mobileNumber: '',
        email: '',
        maritalStatus: '',
        gender: '',
        occupation: '',
        aadharCard: '',
        panCard: '',
        imageFile: null,
    });
    const [isSubmitting, setIsSubmitting] = useState(false);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleFileChange = (e) => {
        setFormData({ ...formData, imageFile: e.target.files[0] });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setIsSubmitting(true);
        const formDataToSend = new FormData();
        for (const key in formData) {
            formDataToSend.append(key, formData[key]);
        }

        try {
            await axios.post('http://localhost:5278/api/Personal_Project/Insert', formDataToSend, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            });
            alert('Entry added successfully');
            setFormData({
                name: '',
                dateOfBirth: '',
                residentialAddress: '',
                permanentAddress: '',
                mobileNumber: '',
                email: '',
                maritalStatus: '',
                gender: '',
                occupation: '',
                aadharCard: '',
                panCard: '',
                imageFile: null,
            });
        } catch (error) {
            console.error('Error posting entry:', error);
            alert('Failed to add entry. Please try again.');
        } finally {
            setIsSubmitting(false);
        }
    };

    return (
        <div className="max-w-2xl mx-auto mt-10 p-6 bg-white rounded-lg shadow-md">
            <h2 className="text-2xl font-bold mb-6 text-center text-gray-800">Add New Entry</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <InputField label="Name" name="name" value={formData.name} onChange={handleChange} required />
                <InputField label="Date of Birth" name="dateOfBirth" type="date" value={formData.dateOfBirth} onChange={handleChange} required />
                <InputField label="Residential Address" name="residentialAddress" value={formData.residentialAddress} onChange={handleChange} required />
                <InputField label="Permanent Address" name="permanentAddress" value={formData.permanentAddress} onChange={handleChange} required />
                <InputField label="Mobile Number" name="mobileNumber" value={formData.mobileNumber} onChange={handleChange} required />
                <InputField label="Email" name="email" type="email" value={formData.email} onChange={handleChange} required />
                <InputField label="Marital Status" name="maritalStatus" value={formData.maritalStatus} onChange={handleChange} required />
                
                <div className="space-y-2">
                    <label className="block text-sm font-medium text-gray-700">Gender</label>
                    <div className="space-x-4">
                        <RadioButton name="gender" value="male" checked={formData.gender === 'male'} onChange={handleChange} label="Male" />
                        <RadioButton name="gender" value="female" checked={formData.gender === 'female'} onChange={handleChange} label="Female" />
                        <RadioButton name="gender" value="other" checked={formData.gender === 'other'} onChange={handleChange} label="Other" />
                    </div>
                </div>
                
                <InputField label="Occupation" name="occupation" value={formData.occupation} onChange={handleChange} required />
                <InputField label="Aadhar Card" name="aadharCard" value={formData.aadharCard} onChange={handleChange} required />
                <InputField label="PAN Card" name="panCard" value={formData.panCard} onChange={handleChange} required />
                
                <div className="space-y-2">
                    <label className="block text-sm font-medium text-gray-700">Profile Image</label>
                    <input
                        type="file"
                        name="imageFile"
                        onChange={handleFileChange}
                        required
                        className="w-full text-sm text-gray-500 file:mr-4 file:py-2 file:px-4 file:rounded-full file:border-0 file:text-sm file:font-semibold file:bg-blue-50 file:text-blue-700 hover:file:bg-blue-100"
                    />
                </div>
                
                <div className="mt-6">
                    <button
                        type="submit"
                        disabled={isSubmitting}
                        className={`w-full py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 ${isSubmitting ? 'opacity-50 cursor-not-allowed' : ''}`}
                    >
                        {isSubmitting ? 'Submitting...' : 'Submit'}
                    </button>
                </div>
            </form>
        </div>
    );
};

const InputField = ({ label, name, type = "text", value, onChange, required }) => (
    <div className="space-y-1">
        <label htmlFor={name} className="block text-sm font-medium text-gray-700">
            {label}
        </label>
        <input
            type={type}
            name={name}
            id={name}
            value={value}
            onChange={onChange}
            required={required}
            className="mt-1 block w-full rounded-md border-gray-300 shadow-sm focus:border-blue-500 focus:ring-blue-500 sm:text-sm"
        />
    </div>
);

const RadioButton = ({ name, value, checked, onChange, label }) => (
    <label className="inline-flex items-center">
        <input
            type="radio"
            name={name}
            value={value}
            checked={checked}
            onChange={onChange}
            className="form-radio h-4 w-4 text-blue-600 transition duration-150 ease-in-out"
        />
        <span className="ml-2 text-sm text-gray-700">{label}</span>
    </label>
);

export default PostEntry;