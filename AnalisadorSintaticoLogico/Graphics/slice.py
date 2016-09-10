from __future__ import division
from PIL import Image
import math
import os

def slice_it(image_path, out_name, outdir, slice_size):
    """slice an image into parts slice_size tall"""
    
    img = Image.open(image_path)
    width, height = img.size
    slices_v = int(math.floor(height/slice_size)) - 1
    slices_h = int(math.floor(width/slice_size)) - 1
    total = slices_v * slices_h

    print ("Slicing the image", image_path, "(", width, "x", height, ") in", slice_size, "x", slice_size, "(", slices_h, slices_v, ") pieces...")

    top = 0
    left = 0

    count = 1
    count_v = 1
    for slice_v in range(slices_v):

        count_h = 1
        for slice_h in range(slices_h):
        
            left = count_h * slice_size
            top = count_v * slice_size
            right = left + slice_size if left + slice_size < width else width - 1
            lower = top + slice_size if  top + slice_size < height else height - 1

            bbox = (left, top, right, lower)
            working_slice = img.crop(bbox)

            #save the slice
            working_slice.save(os.path.join(outdir, "slice_" + out_name + "_" + str(count)+".png"))
            print ("Slice", count, "is (", left, top, right, lower, ").")

            count += 1
            count_h +=1

        count_v +=1

if __name__ == '__main__':
    #slice_size is the max height of the slices in pixels
    slice_it("Symbols.png","symbol", os.getcwd() + "/sliced", 32)
