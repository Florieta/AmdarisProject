import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';

export default function ButtonBasic() {
  return (
    <Stack spacing={2} direction="row">
      <Button variant="outlined">Edit</Button>
      <Button variant="contained">Delete</Button>
    </Stack>
  );
}