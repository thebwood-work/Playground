import './App.css';
import { BrowserRouter } from 'react-router-dom';
import AppRoutes from './routes/AppRoutes';
import Layout from './layout';

function App() {
  return (
    <Layout>
      <BrowserRouter>
        <AppRoutes />
      </BrowserRouter>
    </Layout>
  );
}

export default App;
