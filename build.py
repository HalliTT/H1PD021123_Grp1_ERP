from subprocess import run
from pathlib import Path
from os import path, makedirs, getcwd
    
def outputDir() -> str:
    if not path.exists(str(Path("./Out"))):
        makedirs("./Out")

    return getcwd() + str(Path("/Out"))

def main():
    if not path.isfile("./build.py"):
        print("ERROR: build.py should be runned from root dir")
        exit()
        
    else:
        run(["dotnet", "build", str(Path("./Src")), "--output", outputDir()])

if __name__ == "__main__":
    main()