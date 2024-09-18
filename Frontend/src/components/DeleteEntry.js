import React, { useState } from 'react';
import axios from 'axios';

const DeleteEntry = () => {
    const [id, setId] = useState('');

    const handleDelete = async () => {
        try {
            await axios.delete(`http://localhost:5278/api/Personal_Project/DeleteUser${id}`);
            alert('Entry deleted successfully');
        } catch (error) {
            console.error('Error deleting entry:', error);
        }
    };

    return (
        <div>
            <h2>Delete Entry</h2>
            <input
                type="number"
                placeholder="Enter ID to delete"
                value={id}
                onChange={(e) => setId(e.target.value)}
            />
            <button onClick={handleDelete}>Delete</button>
        </div>
    );
};

export default DeleteEntry;
