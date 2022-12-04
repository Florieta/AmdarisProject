import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Box from '@mui/material/Box';
import { useEffect, useState } from 'react';

function App() {

  const [value, setValue] = useState(0)
  const [cars, setCars] = useState([])

  const handleChange = (_, changedValue) => {
    setValue(changedValue)
  }

  useEffect(() => {
    const fetchCars = async () => {
      const response = await fetch('https://localhost:7016/api/Car')
      const data = await response.json()

      setCars(data)
    }
    fetchCars()

  }, [])

  console.log(cars)

  return (
    <>
      <Box sx={{ borderBottom: 1, borderColor: 'divider' }}>
        <Tabs value={value} onChange={handleChange} aria-label="basic tabs example">
          <Tab label="Item One" id={0} />
          <Tab label="Item Two" id={1} />
          <Tab label="Item Three" id={2} />
        </Tabs>
      </Box>
      {value===0 &&  <Box>{cars.map(car => <Box key={car}>{car}</Box>)}</Box>}
      {/* <TabPanel value={value} index={0}>
        Item One
      </TabPanel>
      <TabPanel value={value} index={1}>
        Item Two
      </TabPanel>
      <TabPanel value={value} index={2}>
        Item Three
      </TabPanel> */}
    </>
  );
}

export default App;
