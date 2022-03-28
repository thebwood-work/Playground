import { Alert, Button, Container, TextField } from "@mui/material";
import moment from "moment";
import React, { FC, Fragment, useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { IPersonDetailModel } from "../../../app/models/people/interfaces/IPersonDetailModel";
import { PersonDetailModel } from "../../../app/models/people/PersonDetailModel";
import PeopleService from "../../../app/services/peopleService";


const PersonDetail: FC = () => {
    const peopleService = new PeopleService();
    const navigate = useNavigate();
    const { id } = useParams();
    const [person, setPerson] = useState<IPersonDetailModel>(new PersonDetailModel());
    const { firstName, lastName, dateOfBirth } = person;
    const [errorMessages, setErrorMessages] = useState<string[]>([]);

    useEffect(() => {
        if (id) {
            peopleService.loadPerson(id)
                .then(response => {
                    if (response)
                        setPerson(response);
                })
                .catch((error) => {});
        }

    }, []);

    const handleSave = () => {
        setErrorMessages([]);
        peopleService.savePerson(person).then((errors) => {
            if (errors && errors.length > 0) {
                setErrorMessages(errors);
            }
            else {
                navigate("/people");
            }
        });
    }

    const handleCancel = () => {
        navigate("/people");
    }

    return (
        <Container maxWidth="md">

            {(errorMessages && errorMessages.length > 0) && errorMessages.map(error => (
                <Alert severity="error">{error}</Alert>
            ))}
            {id ? <h4>Person: {id}</h4> : <h4>Add Person</h4>}
            {
                person &&
                <div className="container">
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="FirstName"
                                label="First Name"
                                fullWidth
                                value={firstName || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setPerson({ ...person, firstName: e.target.value })}
                            ></TextField>

                        </div>
                        <div className="col-6">
                            <TextField
                                id="LastName"
                                label="Last Name"
                                fullWidth
                                value={lastName || ''}
                                inputProps={{
                                    maxLength: 50
                                }}
                                onChange={(e) => setPerson({ ...person, lastName: e.target.value })}
                            ></TextField>

                        </div>
                    </div>
                    <div className="row mb-2">
                        <div className="col-6">
                            <TextField
                                id="BirthDate"
                                label="Date of Birth"
                                type="date"
                                value={dateOfBirth ? moment(dateOfBirth).format("YYYY-MM-DD") : ""}
                                fullWidth
                                onChange={(e) => setPerson({ ...person, dateOfBirth: e.target.value })}
                                InputLabelProps={{
                                    shrink: true,
                                }}
                            />
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

export default PersonDetail;