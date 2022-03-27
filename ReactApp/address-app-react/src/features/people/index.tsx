import axios from "axios";
import React, { FC, Fragment, useEffect, useState } from "react";
import { IPersonModel } from "../../app/models/people/interfaces/IPersonModel";
import { IPersonSearchModel } from "../../app/models/people/interfaces/IPersonSearchModel";
import { PersonSearchModel } from "../../app/models/people/PersonSearchModel";
import { PeopleGrid } from "./components/peopleGrid";
import PersonSearchForm from "./components/personSearchForm";

const People: FC = () => {
    const [people, setPeople] = useState<IPersonModel[]>([]);

    const searchPeople = (personSearchFields: IPersonSearchModel): void => {
        axios.post<IPersonModel[]>('https://localhost:5010/people/search', personSearchFields).then((response) => {
            if(response && response.data)
            {
                setPeople(response.data);
            }
        });
    }


    const deletePerson = (rowId: string | null): void => {
        if(rowId && window.confirm('Are you sure you want to delete this person?')) {
            axios.delete<Boolean>(`https://localhost:5010/people/${rowId}`).then((response) => {
                if(response && response.data)
                {
                    searchPeople(new PersonSearchModel());
                }
            });
        }
    }

    useEffect(() => {
        searchPeople(new PersonSearchModel());
    }, []);

    return(
        <Fragment>
            <div>
                <h1>People List</h1>
            </div>
            <div>
                <PersonSearchForm HandleSearch={searchPeople} />
            </div>
            <div>
                <PeopleGrid rows={people} handleDeleteClick={deletePerson} />
            </div>  
        </Fragment>
    );
}
export default People;

