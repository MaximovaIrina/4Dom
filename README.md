# 4Dom

Smart Infrastructure Challenge: From Paper to 4D Buildings!
<center> Siemens, HackZurich-2022 </center>  


Technical Requirements:
**Though much runtime data is available for most buildings today, the fundamental building data, the floor plans, is only available on paper for the majority of existing buildings. Build a 3D model from floor plans, pump it up with data and visualize it real time.**

### Setup
```bash
virtualenv venv --python=3.8
source venv bin activate
pip install -r requirements.txt
```
### Preprocessing
Use out [preproc.ipynb](preproc.ipynb) notebook for interactivly processing your PDF floor scheme.   
We a sagested pipeline for floor scheme  segmentation.   
Bellow you can see which step of prerpoceesing we a using for that.  

[Floor scheme segmentation](data/seg.gif)

### 3D reconstruction
Using unity, we drew a floor plan of each other 
