
# Use the official Node.js 18 image for the production stage
FROM node:18-alpine AS production

# Set the working directory
WORKDIR /app

# Copy the built files from the builder stage
COPY --from=builder /app ./

# Install only production dependencies
RUN npm ci --only=production

# Expose the port the app runs on
EXPOSE 3000

# Start the Next.js app
CMD ["npm", "start"]