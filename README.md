# Playfair_Visualization
visualizing the playfair algorithm of decrypt and encrypt the message

### Algorithm Explanation:
1- The playfair algorithm is based on the use of 5x5 matrix of letters constructed using a keyword (not repeated)
![1](https://user-images.githubusercontent.com/40705922/116628638-d1a9aa80-a94f-11eb-839c-3c18b4799bb6.JPG)

2- Plaintext is encrypted as two letters as a time, according to the following rules:
- If both the letters are in the same row: Take the letter to the right of each one (going back to the leftmost if at the rightmost position).
- If both the letters are in the same column: Take the letter below each one (going back to the top if at the bottom).
- If neither of the above rules is true: Form a rectangle with the two letters and take the letters on the horizontal opposite corner of the rectangle.
![2](https://user-images.githubusercontent.com/40705922/116628629-ce162380-a94f-11eb-90e7-d2a708aa053b.JPG)

Example: P.T = communication, Keyword = “playfairexample”
![3](https://user-images.githubusercontent.com/40705922/116628604-c22a6180-a94f-11eb-94bb-ba41974436ae.JPG)

Example:
![4] https://user-images.githubusercontent.com/40705922/156396281-3a477a16-d905-48df-a635-dace7a1c2c25.mp4
