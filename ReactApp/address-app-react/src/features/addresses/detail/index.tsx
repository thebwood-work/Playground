import { Alert, Button, Container, TextField } from "@mui/material";
import React, { FC, Fragment, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { AddressDetailModel } from "../../../app/models/addresses/AddressDetailModel";
import { IAddressDetailModel } from "../../../app/models/addresses/interfaces/IAddressDetailModel";
import AddressService from "../../../app/services/addressService";


const AddressDetail: FC = () => {
    const addressService = new AddressService();
    const navigate = useNavigate();
    const { id } = useParams();
    const [address, setAddress] = useState<IAddressDetailModel>(new AddressDetailModel());
    const { streetName, streetNumber, city, stateId, zipCode } = address;
    const [errorMessages, setErrorMessages] = useState<string[]>([]);

    useEffect(() => {
        if (id) {
            addressService.loadAddress(id).then(response => {
                if (response)
                    setAddress(response);
                else {
                    let errors = [];
                    errors.push('Something went wrong');
                    setErrorMessages(errors);
                }
            });
        }

    }, []);

    const handleSave = () => {
        setErrorMessages([]);
        addressService.saveAddress(address).then((errors) => {
            if (errors && errors.length > 0) {
                setErrorMessages(errors);
            }
            else {
                navigate("/addresses");
            }
        });
    }

    const handleCancel = () => {
        navigate("/addresses");
    }

    return (
        <Container maxWidth="md">

            {(errorMessages && errorMessages.length > 0) && errorMessages.map(error => (
                <Alert severity="error">{error}</Alert>
            ))}
            {id ? <h4>Address: {id}</h4> : <h4>Add Address</h4>}
            {
                address &&
                <div className="container">
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="StreetNumber"
                                label="Street Number"
                                fullWidth
                                value={streetNumber || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, streetNumber: e.target.value })}
                            ></TextField>

                        </div>
                        <div className="col-6">
                            <TextField
                                id="StreetName"
                                label="Street Name"
                                fullWidth
                                value={streetName || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, streetName: e.target.value })}
                            ></TextField>

                        </div>
                    </div>
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="City"
                                label="City"
                                fullWidth
                                value={city || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setAddress({ ...address, city: e.target.value })}
                            ></TextField>
                        </div>

                    </div>
                    <div className="row mb-2">
                        <div className="col-12 text-right">
                            <Button className="mr-1" variant="contained" onClick={() => handleSave()}>Save</Button>
                            <Button variant="contained" color="error" onClick={() => handleCancel()}>Cancel</Button>
                        </div>
                    </div>
                </div>
            }

        </Container>

    );

}

export default AddressDetail;