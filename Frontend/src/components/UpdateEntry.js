import React, { useState } from 'react';
import axios from 'axios';

const UpdateEntry = () => {
    const [id, setId] = useState('');
    const [phoneNumber, setPhoneNumber] = useState('');
    const [permanentAddress, setPermanentAddress] = useState('');

    const handleUpdate = async () => {
        try {
            await axios.put(`http://localhost:5278/api/Personal_Project/UpdateUser/${id}`, {
                phoneNumber,
                permanentAddress,
            });
            alert('Entry updated successfully');
        } catch (error) {
            console.error('Error updating entry:', error);
        }
    };

    return (
        <div>
            <h2>Update Entry</h2>
            <input
                type="number"
                placeholder="Enter ID to update"
                value={id}
                onChange={(e) => setId(e.target.value)}
            />
            <input
                type="text"
                placeholder="New Phone Number"
                value={phoneNumber}
                onChange={(e) => setPhoneNumber(e.target.value)}
            />
            <input
                type="text"
                placeholder="New Permanent Address"
                value={permanentAddress}
                onChange={(e) => setPermanentAddress(e.target.value)}
            />
            <button onClick={handleUpdate}>Update</button>
        </div>
    );
};

export default UpdateEntry;
