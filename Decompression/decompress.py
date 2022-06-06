import sys
import gzip
import shutil
from pathlib import Path

def decompress(source: Path, dest: Path):
    try:
        with gzip.open(str(source), 'rb') as source_file:
            with open(str(dest), 'wb') as dest_file:
                shutil.copyfileobj(source_file, dest_file)
    except Exception as e:
        print('Failed to decompress data:', e)

if __name__ == '__main__':
    if len(sys.argv) != 3:
        print('Invalid usage.')
        print('python3 decompress.py [source] [dest]')
        sys.exit()

    source = sys.argv[1]
    dest = sys.argv[2]
    decompress(source, dest)