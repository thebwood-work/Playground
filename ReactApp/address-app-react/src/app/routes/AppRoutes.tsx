import { FC } from "react";
import { Route, Routes } from "react-router-dom";
import Dashboard from "../../features/dashboard";



const AppRoutes: FC = () => {
    return <Routes>
        <Route path="*" element={<Dashboard />} />
    </Routes>;
}
export default AppRoutes;

