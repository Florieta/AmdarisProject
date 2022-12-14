import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';

export default function CancelButton() {
  return (
    <Stack direction="row" spacing={2}>
      <Button variant="outlined" color="error">
        Cancel
      </Button>
    </Stack>
  );
}