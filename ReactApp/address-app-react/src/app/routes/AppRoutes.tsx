import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import Dashboard from "../../features/dashboard";
import People from "../../features/people";
import PersonDetail from "../../features/people/detail";



const AppRoutes: FC = () => {
    return <Routes>
        <Route path="people/add" element={<PersonDetail />} />
        <Route path="people/:id" element={<PersonDetail />} />
        <Route path="people" element={<People />} />
        <Route path="*" element={<Dashboard />} />
    </Routes>;
}
export default AppRoutes;

