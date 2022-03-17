import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import Dashboard from "../../features/dashboard";
import People from "../../features/people";



const AppRoutes: FC = () => {
    return <Routes>
        <Route path="people" element={<People />} />
        <Route path="*" element={<Dashboard />} />
    </Routes>;
}
export default AppRoutes;

