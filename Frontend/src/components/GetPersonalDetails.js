import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { User } from 'lucide-react';

const GetPersonalDetails = () => {
    const [personalData, setPersonalData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchPersonalData = async () => {
            try {
                const response = await axios.get('http://localhost:5278/api/Personal_Project');
                setPersonalData(response.data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching personal details:', error);
                setError('Failed to load data. Please try again later.');
                setLoading(false);
            }
        };

        fetchPersonalData();
    }, []);

    if (loading) return <div className="text-center py-10">Loading...</div>;
    if (error) return <div className="text-center py-10 text-red-500">{error}</div>;

    return (
        <div className="container mx-auto px-4 py-8">
            <h2 className="text-2xl font-bold mb-6 text-indigo-700">Personal Details</h2>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                {personalData.map((data) => (
                    <div key={data.id} className="bg-white rounded-lg shadow-md overflow-hidden">
                        <div className="bg-indigo-100 p-4">
                            <User className="w-16 h-16 mx-auto text-indigo-500" />
                        </div>
                        <div className="p-4">
                            <h3 className="font-bold text-lg mb-2">{data.name}</h3>
                            <p className="text-sm text-gray-600 mb-1">DOB: {new Date(data.dateOfBirth).toLocaleDateString()}</p>
                            <p className="text-sm text-gray-600 mb-1">Email: {data.email}</p>
                            <p className="text-sm text-gray-600 mb-1">Phone: {data.mobileNumber}</p>
                            <p className="text-sm text-gray-600">Occupation: {data.occupation}</p>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default GetPersonalDetails;